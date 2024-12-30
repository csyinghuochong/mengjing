using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestMove : MonoBehaviour
{

    private Vector3 m_targetpos;
    private Transform followTarget ;
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    public float moveSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        GameObject camera = GameObject.Find("Main Camera");
        CameraControl cc =  camera.AddComponent<CameraControl>();
        cc.followTarget = this.transform;
        followTarget = this.transform;
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        animator = gameObject.GetComponentInChildren<Animator>();

        Debug.Log("followTarget = " + followTarget);

    }


    private void GetKeyboardMoveMent()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //this.mLastMousePosition = Input.mousePosition;

            //����һ�������������������
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //�����洢���ߴ����������Ϣ
            RaycastHit hit;
            //��������
            bool result = Physics.Raycast(ray, out hit);
            //���Ϊtrue˵������������
            if (result)
            {
                //��ȡ���ߴ��е�����
                //hit.collider;
                //��ȡ���ߴ��е����꣨����һ���������꣩
                //hit.point;

                //��ȡ���е�Ŀ��
                m_targetpos = hit.point;

                navMeshAgent.speed = moveSpeed;

                bool bbb = navMeshAgent.isOnNavMesh;
                navMeshAgent.isStopped = false;
                navMeshAgent.SetDestination(hit.point);
                //animator.SetFloat(AnimatorConstant.MoveIdleBlend, 1);
                //��
                animator.Play("Run");
            }
            else
            {

                navMeshAgent.isStopped = true;
                //m_targetpos = Vector3.zero;
                //animator.SetFloat(AnimatorConstant.MoveIdleBlend, 0);

                //ͣ
                animator.Play("Idle");
            }
        }
    }

    void LateUpdate()
    {
        GetKeyboardMoveMent();
    }

    // Update is called once per frame
    void Update()
    {
        //if (m_targetpos == Vector3.zero)
        //    return;


        //�ƶ�
        ///followTarget.Translate(Vector3.forward * 5 * Time.deltaTime);
        //��⵽�յ�ľ���
        if (followTarget != null)
        {
            if (Vector3.Distance(followTarget.position, m_targetpos) < 0.2f)
            {
                //�����յ�
                navMeshAgent.isStopped = true;
                //animator.SetFloat(AnimatorConstant.MoveIdleBlend, 0);
                animator.Play("Idle");
            }
            else
            {
                //����ɫת��ָ���ķ���
                followTarget.rotation = Quaternion.Lerp(followTarget.rotation, Quaternion.LookRotation(m_targetpos - new Vector3(followTarget.position.x, followTarget.position.y, followTarget.position.z)), Time.deltaTime * 20f);
            }
        }
    }
}


class AnimatorConstant
{
    public const string StandbyId = "StandbyId";
    public const string ButtonDown = "ButtonDown";
    public const string ButtonId = "ButtonId";
    public const string ButtonIdIndex = "ButtonIdIndex";
    public const string MoveIdleBlend = "MoveIdleBlend";
    public const string NormalizedTime = "NormalizedTime";
    public const string HasBuff = "HasBuff";
    public const string WeienW = "WeienW";
    public const string MoveDirection = "MoveDirection";
    public static readonly int SkillTag = Animator.StringToHash("skill");
    public static readonly int AttackTag = Animator.StringToHash("attack");
    public static readonly int RushTag = Animator.StringToHash("rush");
    public static readonly int FlyTag = Animator.StringToHash("fly");
    public static readonly int RushSkillTag = Animator.StringToHash("rush_skill");
    public static readonly int NormalTag = Animator.StringToHash("normal");
    public static readonly int AimTag = Animator.StringToHash("aim");
    public static readonly int CGEndTag = Animator.StringToHash("cg_end");
    public static readonly int TractionTag = Animator.StringToHash("traction");

    public const string RushSucceed = "RushSucceed";
    public const string Traction = "Traction";
    public const string TractionSucceed = "TractionSucceed";
    public const string LoopEnd = "LoopEnd";

    //events

    public const string ActionStart = "START";
    public const string ActionEnd = "END";
    public const string OnBorn = "BORN";

}