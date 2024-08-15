# 使用Animancer

- 物体要添加组件Animator(可不添加引用Controller)、AnimancerComponent、AnimData(要添加AnimGroup)

# 由AnimatorController生成AnimGroup 单独

- 打开 Tools/Animancer/Generate AnimGroup
- 填写参数后生成

# 由AnimatorController生成AnimGroup 批量

- 打开 Tools/Animancer/Generate Multi AnimGroup
- 填写参数后生成，并自动为每个物体的AnimData添加对应的AnimGroup
- ！！！注意！！！ 生成的AnimGroup存放的位置是与每个物体的存放位置相关连的，若2个物体引用同一个AnimatorController，但是物体不在同一个文件夹内，则会生成2个AnimGroup分别在不同的文件夹内，2个物体引用的AnimGroup对象不同