using System;
using CommandLine;

namespace ET.Server
{
    [ConsoleHandler(ConsoleMode.CreateRobot)]
    public class CreateRobotConsoleHandler: IConsoleHandler
    {
        public async ETTask Run(Fiber fiber, ModeContex contex, string content)
        {
            switch (content)
            {
                case ConsoleMode.CreateRobot:
                {
                    Log.Console("CreateRobot args error!");
                    break;
                }
                default:
                {
                    //CreateRobot --Num=1 --RobotId=1000
                    CreateRobotArgs options = null;
                    Parser.Default.ParseArguments<CreateRobotArgs>(content.Split(' '))
                            .WithNotParsed(error => throw new Exception($"CreateRobotArgs error!"))
                            .WithParsed(o => { options = o; });

                    RobotManagerComponent robotManagerComponent =
                            fiber.Root.GetComponent<RobotManagerComponent>() ?? fiber.Root.AddComponent<RobotManagerComponent>();
                    
                    // 创建机器人
                    TimerComponent timerComponent = fiber.Root.GetComponent<TimerComponent>();
                    for (int i = 0; i < options.Num; ++i)
                    {
                        await robotManagerComponent.NewRobot(1, options.RobotId);
                        Log.Console($"create robot {i}");
                        await timerComponent.WaitAsync(2000);
                    }
                    break;
                }
            }
            contex.Parent.RemoveComponent<ModeContex>();
            await ETTask.CompletedTask;
        }
    }
}