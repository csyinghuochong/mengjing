// Animancer // https://kybernetik.com.au/animancer // Copyright 2018-2023 Kybernetik //
// FlexiMotion // https://kybernetik.com.au/flexi-motion // Copyright 2023 Kybernetik //

#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value.

#if UNITY_EDITOR

using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Animancer.Editor
//namespace FlexiMotion.Editor
{
    /// <summary>[Editor-Only] A welcome screen for an asset.</summary>
    /// https://kybernetik.com.au/animancer/api/Animancer.Editor/ReadMe
    /// https://kybernetik.com.au/flexi-motion/api/FlexiMotion.Editor/ReadMe
    /// 
    public abstract class ReadMe : ScriptableObject
    {
        /************************************************************************************************************************/
        #region Fields and Properties
        /************************************************************************************************************************/

        /// <summary>The release ID of the current version.</summary>
        protected abstract int ReleaseNumber { get; }

        /// <summary>The display name of this product version.</summary>
        protected abstract string VersionName { get; }

        /// <summary>The URL for the change log of this version.</summary>
        protected abstract string ChangeLogURL { get; }

        /// <summary>The key used to save the release number.</summary>
        protected abstract string PrefKey { get; }

        /// <summary>An introductory explanation of this asset.</summary>
        protected virtual string Introduction => null;

        /// <summary>The base name of this product (without any "Lite", "Pro", "Demo", etc.).</summary>
        protected abstract string BaseProductName { get; }

        /// <summary>The name of this product.</summary>
        protected virtual string ProductName => BaseProductName;

        /// <summary>The URL for the documentation.</summary>
        protected abstract string DocumentationURL { get; }

        /// <summary>The display name for the examples section.</summary>
        protected virtual string ExamplesLabel => "Examples";

        /// <summary>The URL for the example documentation.</summary>
        protected abstract string ExampleURL { get; }

        /************************************************************************************************************************/

        /// <summary>
        /// The <see cref="ReadMe"/> file name ends with the <see cref="VersionName"/> to detect if the user imported
        /// this version without deleting a previous version.
        /// </summary>
        /// <remarks>
        /// When Unity's package importer sees an existing file with the same GUID as one in the package, it will
        /// overwrite that file but not move or rename it if the name has changed. So it will leave the file there with
        /// the old version name.
        /// </remarks>
        private bool HasCorrectName => name.EndsWith(VersionName);

        /************************************************************************************************************************/

        [SerializeField] private DefaultAsset _ExamplesFolder;

        /// <summary>Sections to be displayed below the examples.</summary>
        public LinkSection[] LinkSections { get; set; }

        /// <summary>Extra sections to be displayed with the examples.</summary>
        public LinkSection[] ExtraExamples { get; set; }

        /************************************************************************************************************************/

        /// <summary>Creates a new <see cref="ReadMe"/> and sets the <see cref="LinkSections"/>.</summary>
        public ReadMe(params LinkSection[] linkSections)
        {
            LinkSections = linkSections;
        }

        /************************************************************************************************************************/

        /// <summary>A heading with a link to be displayed in the Inspector.</summary>
        public class LinkSection
        {
            /************************************************************************************************************************/

            /// <summary>The main label.</summary>
            public readonly string Heading;

            /// <summary>A short description to be displayed near the <see cref="Heading"/>.</summary>
            public readonly string Description;

            /// <summary>A link that can be opened by clicking the <see cref="Heading"/>.</summary>
            public readonly string URL;

            /// <summary>An optional user-friendly version of the <see cref="URL"/>.</summary>
            public readonly string DisplayURL;

            /************************************************************************************************************************/

            /// <summary>Creates a new <see cref="LinkSection"/>.</summary>
            public LinkSection(string heading, string description, string url, string displayURL = null)
            {
                Heading = heading;
                Description = description;
                URL = url;
                DisplayURL = displayURL;
            }

            /************************************************************************************************************************/
        }

        /************************************************************************************************************************/

        /// <summary>Returns a <c>mailto</c> link.</summary>
        public static string GetEmailURL(string address, string subject)
            => $"mailto:{address}?subject={subject.Replace(" ", "%20")}";

        /************************************************************************************************************************/
        #endregion
        /************************************************************************************************************************/
        #region Custom Editor
        /************************************************************************************************************************/

        /// <summary>[Editor-Only] A custom Inspector for <see cref="ReadMe"/>.</summary>
        [CustomEditor(typeof(ReadMe), editorForChildClasses: true)]
        public class Editor : UnityEditor.Editor
        {
            /************************************************************************************************************************/

            private static readonly GUIContent
                GUIContent = new GUIContent();

            [NonSerialized] private ReadMe _Target;
            [NonSerialized] private Texture2D _Icon;
            [NonSerialized] private string _ReleaseNumberPrefKey;
            [NonSerialized] private int _PreviousVersion;
            [NonSerialized] private string _ExamplesDirectory;
            [NonSerialized] private List<ExampleGroup> _Examples;
            [NonSerialized] private string _Title;

            /************************************************************************************************************************/

            /// <summary>Don't use any margins.</summary>
            public override bool UseDefaultMargins() => false;

            /************************************************************************************************************************/

            protected virtual void OnEnable()
            {
                _Target = (ReadMe)target;
                _Icon = AssetPreview.GetMiniThumbnail(target);

                _ReleaseNumberPrefKey = _Target.PrefKey + "." + nameof(_Target.ReleaseNumber);
                _PreviousVersion = PlayerPrefs.GetInt(_ReleaseNumberPrefKey, -1);

                _Examples = ExampleGroup.Gather(_Target._ExamplesFolder, out _ExamplesDirectory);

                _Title = $"{_Target.ProductName}\n{_Target.VersionName}";
            }

            /************************************************************************************************************************/

            protected override void OnHeaderGUI()
            {
                GUILayout.BeginHorizontal(Styles.TitleArea);
                {
                    GUIContent.text = _Title;
                    GUIContent.tooltip = null;

                    var iconWidth = Styles.Title.CalcHeight(GUIContent, EditorGUIUtility.currentViewWidth);
                    GUILayout.Label(_Icon, GUILayout.Width(iconWidth), GUILayout.Height(iconWidth));
                    GUILayout.Label(GUIContent, Styles.Title);
                }
                GUILayout.EndHorizontal();
            }

            /************************************************************************************************************************/

            /// <inheritdoc/>
            public override void OnInspectorGUI()
            {
                serializedObject.Update();

                DoIntroduction();

                DoSpace();

                DoWarnings();

                DoSpace();

                DoIntroductionBlock();

                DoSpace();

                DoExampleBlock();

                DoSpace();

                DoSupportBlock();

                DoSpace();

                serializedObject.ApplyModifiedProperties();
            }

            /************************************************************************************************************************/

            protected static void DoSpace() => GUILayout.Space(EditorGUIUtility.singleLineHeight * 0.2f);

            /************************************************************************************************************************/

            private void DoIntroduction()
            {
                var introduction = _Target.Introduction;
                if (introduction == null)
                    return;

                DoSpace();
                GUILayout.Label(introduction, EditorStyles.wordWrappedLabel);
            }

            /************************************************************************************************************************/

            private void DoWarnings()
            {
                MessageType messageType;

                if (!_Target.HasCorrectName)
                {
                    messageType = MessageType.Error;
                }
                else if (_PreviousVersion >= 0 && _PreviousVersion < _Target.ReleaseNumber)
                {
                    messageType = MessageType.Warning;
                }
                else return;

                // Upgraded from any older version.

                DoSpace();

                var directory = AssetDatabase.GetAssetPath(_Target);
                if (string.IsNullOrEmpty(directory))
                    return;

                directory = Path.GetDirectoryName(directory);

                var productName = _Target.ProductName;

                string versionWarning;
                if (messageType == MessageType.Error)
                {
                    versionWarning = $"You must fully delete any old version of {productName} before importing a new version." +
                        $"\n1. Check the Upgrade Guide in the Change Log." +
                        $"\n2. Click here to delete '{directory}'." +
                        $"\n3. Import {productName} again.";
                }
                else
                {
                    versionWarning = $"You must fully delete any old version of {productName} before importing a new version." +
                        $"\n1. Ignore this message if you have already deleted the old version." +
                        $"\n2. Check the Upgrade Guide in the Change Log." +
                        $"\n3. Click here to delete '{directory}'." +
                        $"\n4. Import {productName} again.";
                }

                EditorGUILayout.HelpBox(versionWarning, messageType);
                CheckDeleteDirectory(directory);

                DoSpace();
            }

            /************************************************************************************************************************/

            /// <summary>Asks if the user wants to delete the `directory` and does so if they confirm.</summary>
            private void CheckDeleteDirectory(string directory)
            {
                if (!TryUseClickEventInLastRect())
                    return;

                var name = _Target.ProductName;

                if (!AssetDatabase.IsValidFolder(directory))
                {
                    Debug.Log($"{directory} doesn't exist." +
                        $" You must have moved {name} somewhere else so you will need to delete it manually.", this);
                    return;
                }

                if (!EditorUtility.DisplayDialog($"Delete {name}? ",
                    $"Would you like to delete {directory}?\n\nYou will then need to reimport {name} manually.",
                    "Delete", "Cancel"))
                    return;

                AssetDatabase.DeleteAsset(directory);
            }

            /************************************************************************************************************************/

            /// <summary>
            /// Returns true and uses the current event if it is <see cref="EventType.MouseUp"/> inside the specified
            /// `area`.
            /// </summary>
            public static bool TryUseClickEvent(Rect area, int button = -1)
            {
                var currentEvent = Event.current;
                if (currentEvent.type != EventType.MouseUp ||
                    (button >= 0 && currentEvent.button != button) ||
                    !area.Contains(currentEvent.mousePosition))
                    return false;

                GUI.changed = true;
                currentEvent.Use();

                if (currentEvent.button == 2)
                    GUIUtility.keyboardControl = 0;

                return true;
            }

            /// <summary>
            /// Returns true and uses the current event if it is <see cref="EventType.MouseUp"/> inside the last GUI Layout
            /// <see cref="Rect"/> that was drawn.
            /// </summary>
            public static bool TryUseClickEventInLastRect(int button = -1)
                => TryUseClickEvent(GUILayoutUtility.GetLastRect(), button);

            /************************************************************************************************************************/

            protected virtual void DoIntroductionBlock()
            {
                GUILayout.BeginVertical(Styles.Block);

                DoHeadingLink("Documentation", null, _Target.DocumentationURL);

                DoSpace();

                DoHeadingLink("Change Log", null, _Target.ChangeLogURL);

                GUILayout.EndVertical();
            }

            /************************************************************************************************************************/

            protected virtual void DoExampleBlock()
            {
                GUILayout.BeginVertical(Styles.Block);

                DoHeadingLink(_Target.ExamplesLabel, null, _Target.ExampleURL);
                if (_Target._ExamplesFolder != null)
                {
                    EditorGUILayout.ObjectField(_ExamplesDirectory, _Target._ExamplesFolder, typeof(SceneAsset), false);

                    ExampleGroup.DoExampleGUI(_Examples);
                }

                DoExtraExamples();

                GUILayout.EndVertical();
            }

            /************************************************************************************************************************/

            protected virtual void DoExtraExamples()
            {
                if (_Target.ExtraExamples == null)
                    return;

                for (int i = 0; i < _Target.ExtraExamples.Length; i++)
                {
                    if (i > 0)
                        DoSpace();

                    var section = _Target.ExtraExamples[i];
                    DoHeadingLink(
                        section.Heading,
                        section.Description,
                        section.URL,
                        section.DisplayURL,
                        GUI.skin.label.fontSize);
                }
            }

            /************************************************************************************************************************/

            protected virtual void DoSupportBlock()
            {
                GUILayout.BeginVertical(Styles.Block);

                for (int i = 0; i < _Target.LinkSections.Length; i++)
                {
                    if (i > 0)
                        DoSpace();

                    var section = _Target.LinkSections[i];
                    DoHeadingLink(
                        section.Heading,
                        section.Description,
                        section.URL,
                        section.DisplayURL);
                }

                GUILayout.EndVertical();
            }

            /************************************************************************************************************************/

            protected void DoHeadingLink(
                string heading,
                string description,
                string url,
                string displayURL = null,
                int fontSize = 22)
            {
                // Heading.
                var style = url == null
                    ? Styles.HeaderLabel
                    : Styles.HeaderLink;
                var area = DoLinkButton(heading, url, style, fontSize);

                // Description.

                area.y += EditorGUIUtility.standardVerticalSpacing;

                var urlHeight = Styles.URL.fontSize + Styles.URL.margin.vertical;
                area.height -= urlHeight;

                if (description != null)
                    GUI.Label(area, description, Styles.Description);

                // URL.

                area.y += area.height;
                area.height = urlHeight;

                if (displayURL == null)
                    displayURL = url;

                if (displayURL != null)
                {
                    GUIContent.text = displayURL;
                    GUIContent.tooltip = "Click to copy this link to the clipboard";

                    if (GUI.Button(area, GUIContent, Styles.URL))
                    {
                        GUIUtility.systemCopyBuffer = displayURL;
                        Debug.Log($"Copied '{displayURL}' to the clipboard.", this);
                    }

                    EditorGUIUtility.AddCursorRect(area, MouseCursor.Text);
                }
            }

            /************************************************************************************************************************/

            protected Rect DoLinkButton(string text, string url, GUIStyle style, int fontSize = 22)
            {
                GUIContent.text = text;
                GUIContent.tooltip = url;

                style.fontSize = fontSize;

                var size = style.CalcSize(GUIContent);
                var area = GUILayoutUtility.GetRect(0, size.y);

                var linkArea = new Rect(area.x, area.y, size.x, area.height);
                area.xMin += size.x;

                if (url == null)
                {
                    GUI.Label(linkArea, GUIContent, style);
                }
                else
                {
                    if (GUI.Button(linkArea, GUIContent, style))
                        Application.OpenURL(url);

                    EditorGUIUtility.AddCursorRect(linkArea, MouseCursor.Link);

                    DrawLine(
                        new Vector2(linkArea.xMin, linkArea.yMax),
                        new Vector2(linkArea.xMax, linkArea.yMax),
                        style.normal.textColor);
                }

                return area;
            }

            /************************************************************************************************************************/

            /// <summary>Draws a line between the `start` and `end` using the `color`.</summary>
            public static void DrawLine(Vector2 start, Vector2 end, Color color)
            {
                var previousColor = Handles.color;
                Handles.BeginGUI();
                Handles.color = color;
                Handles.DrawLine(start, end);
                Handles.color = previousColor;
                Handles.EndGUI();
            }

            /************************************************************************************************************************/

            /// <summary>Various <see cref="GUIStyle"/>s used by the <see cref="Editor"/>.</summary>
            protected static class Styles
            {
                /************************************************************************************************************************/

                public static readonly GUIStyle TitleArea = "In BigTitle";

                public static readonly GUIStyle Title = new GUIStyle(GUI.skin.label)
                {
                    fontSize = 26,
                };

                public static readonly GUIStyle Block = GUI.skin.box;

                public static readonly GUIStyle HeaderLabel = new GUIStyle(GUI.skin.label)
                {
                    stretchWidth = false,
                };

                public static readonly GUIStyle HeaderLink = new GUIStyle(HeaderLabel);

                public static readonly GUIStyle Description = new GUIStyle(GUI.skin.label)
                {
                    alignment = TextAnchor.LowerLeft,
                };

                public static readonly GUIStyle URL = new GUIStyle(GUI.skin.label)
                {
                    fontSize = 9,
                    alignment = TextAnchor.LowerLeft,
                };

                /************************************************************************************************************************/

                static Styles()
                {
                    HeaderLink.normal.textColor = HeaderLink.hover.textColor =
                        new Color32(0x00, 0x78, 0xDA, 0xFF);

                    URL.normal.textColor = Color.Lerp(URL.normal.textColor, Color.grey, 0.8f);
                }

                /************************************************************************************************************************/
            }

            /************************************************************************************************************************/

            /// <summary>A group of example scenes.</summary>
            private class ExampleGroup
            {
                /************************************************************************************************************************/

                /// <summary>The name of this group.</summary>
                public readonly string Name;

                /// <summary>The scenes in this group.</summary>
                public readonly List<SceneAsset> Scenes = new List<SceneAsset>();

                /// <summary>The folder paths of each of the <see cref="Scenes"/>.</summary>
                public readonly List<string> Directories = new List<string>();

                /// <summary>Indicates whether this group should show its contents in the GUI.</summary>
                private bool _IsExpanded;

                /// <summary>Is this group always expanded?</summary>
                private bool _AlwaysExpanded;

                /************************************************************************************************************************/

                public static List<ExampleGroup> Gather(DefaultAsset rootDirectoryAsset, out string examplesDirectory)
                {
                    if (rootDirectoryAsset == null)
                    {
                        examplesDirectory = null;
                        return null;
                    }

                    examplesDirectory = AssetDatabase.GetAssetPath(rootDirectoryAsset);
                    if (string.IsNullOrEmpty(examplesDirectory))
                        return null;

                    var directories = Directory.GetDirectories(examplesDirectory);
                    var groups = new List<ExampleGroup>();
                    var allGroupsHaveOneScene = true;

                    for (int i = 0; i < directories.Length; i++)
                    {
                        var group = Gather(examplesDirectory, directories[i]);
                        if (group != null)
                        {
                            groups.Add(group);
                            if (group.Scenes.Count > 1)
                                allGroupsHaveOneScene = false;
                        }
                    }

                    if (groups.Count == 0)
                    {
                        var group = Gather(examplesDirectory, examplesDirectory);
                        if (group != null)
                        {
                            groups.Add(group);
                            if (group.Scenes.Count > 1)
                                allGroupsHaveOneScene = false;
                        }
                    }

                    if (allGroupsHaveOneScene)
                        for (int i = 0; i < groups.Count; i++)
                            groups[i]._AlwaysExpanded = true;

                    examplesDirectory = Path.GetDirectoryName(examplesDirectory);

                    return groups;
                }

                /************************************************************************************************************************/

                public static ExampleGroup Gather(string rootDirectory, string directory)
                {
                    var files = Directory.GetFiles(directory, "*.unity", SearchOption.AllDirectories);

                    List<SceneAsset> scenes = null;

                    for (int j = 0; j < files.Length; j++)
                    {
                        var scene = AssetDatabase.LoadAssetAtPath<SceneAsset>(files[j]);
                        if (scene != null)
                        {
                            if (scenes == null)
                                scenes = new List<SceneAsset>();
                            scenes.Add(scene);
                        }
                    }

                    if (scenes == null)
                        return null;

                    return new ExampleGroup(rootDirectory, directory, scenes);
                }

                /************************************************************************************************************************/

                public ExampleGroup(string rootDirectory, string directory, List<SceneAsset> scenes)
                {
                    var start = rootDirectory.Length + 1;
                    Name = start < directory.Length ?
                        directory.Substring(start, directory.Length - start) :
                        Path.GetFileName(directory);
                    Scenes = scenes;

                    start = directory.Length + 1;

                    for (int i = 0; i < scenes.Count; i++)
                    {
                        directory = AssetDatabase.GetAssetPath(scenes[i]);

                        directory = directory.Substring(start, directory.Length - start);
                        directory = Path.GetDirectoryName(directory);
                        Directories.Add(directory);
                    }
                }

                /************************************************************************************************************************/

                public static void DoExampleGUI(List<ExampleGroup> examples)
                {
                    if (examples == null)
                        return;

                    for (int i = 0; i < examples.Count; i++)
                        examples[i].DoExampleGUI();
                }

                public void DoExampleGUI()
                {
                    if (_AlwaysExpanded)
                    {
                        for (int i = 0; i < Scenes.Count; i++)
                        {
                            EditorGUILayout.ObjectField(Directories[i], Scenes[i], typeof(SceneAsset), false);
                        }

                        return;
                    }

                    EditorGUI.indentLevel++;

                    GUIContent.text = Name;
                    GUIContent.tooltip = null;

                    _IsExpanded = EditorGUILayout.Foldout(_IsExpanded, GUIContent, true);

                    if (_IsExpanded)
                    {
                        EditorGUI.indentLevel++;

                        for (int i = 0; i < Scenes.Count; i++)
                        {
                            EditorGUILayout.ObjectField(Directories[i], Scenes[i], typeof(SceneAsset), false);
                        }

                        EditorGUI.indentLevel--;
                    }

                    EditorGUI.indentLevel--;
                }

                /************************************************************************************************************************/
            }

            /************************************************************************************************************************/
        }

        /************************************************************************************************************************/
        #endregion
        /************************************************************************************************************************/
    }
}

#endif

