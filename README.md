# MCSharp（MC#）
该项目旨在让开发者可以利用C#的方式进行数据包开发，并利用C#中的诸多特性协助数据包的开放 

此项目处于起步阶段，目前已经搭建完毕函数的编程，并将所有的命令打包放入了C#中

## 计划单
* 函数编程框架搭建（已完成）
* 基本命令C#化（已完成）
* 记分板操作（进行中）
* 实体与nbt操作（计划中）
* 原始JSON文本（计划中）
* ...

## 简单例子
在MC#中，一个命令函数是由C#中的一个静态函数定义的。并且，在此静态函数中调用命令之前，必须添加`[MCFunction]`特性，表明此函数为命令函数。值得注意的是，如果在未标记命令函数的地方调用了命令，那么MCSharp会顺着栈向上找，直到找到被标记为命令函数的函数为止，同时将这条命令塞到这个函数中。若没有找到命令函数，则会报错。

命令函数对应命名转换规则是，C#函数所在类的命名空间为命令函数命名空间，而类则为存放命令函数的文件夹，函数的名字则是命令函数的名字。值得注意的是，这些名字仍然需要符合Minecraft对数据包中函数命名空间的要求，即只能包含字母数字和下划线。在转换时，会自动将原函数的命名空间，类，名字等的大写字母自动转换为小写。

下面是一个简单的实例程序。它展示了C#中创建一个数据包的基本操作，并且展示了MC#的基本编程逻辑。

```C#
using MCSharp.Attribute;
using static MCSharp.Cmds.Commands;

namespace MCSharp.Test
{
    internal class Test
    {
        public static void Main(string[] args)
        {
            //初始化数据包，设置路径，版本，描述和名称
            DatapackInfo.Init("D:\\.minecraft\\saves\\Datapack Lab\\datapacks", 10, "qwq", "qwq");
            qwq();  //功能函数的入口
            DatapackInfo.Create();      //生成数据包
        }

        [MCFunction]
        [FunctionTag("qwq","owo")]
        public static void qwq()
        {
            Say("qwq");
            test();
        }

        public static void test()
        {
            //Say("test");  不能在非命令函数中调用命令
            awa();
        }

        [MCFunction]
        public static void awa()
        {
            Say("awa");
        }
    }
}
```
它会生成这样的数据包：
```mcfunction
mcsharp:datapackinfo/init
        scoreboard objectives add mcs_intvar dummy
        scoreboard objectives add mcs_default dummy
mcsharp_test:test/qwq
        say qwq
        function mcsharp_test:test/awa
mcsharp_test:test/awa
        say awa
```
你可能会注意到，在Main函数中并不能直接调用命令，而是需要一个称作功能函数入口的东西调用一个函数，在函数中执行。

这样的逻辑是，在数据包中，它每实现一个功能，要使用这个功能时，必定会调用一个根函数。这个函数可能是玩家手动调用，也可能是tick或者load这样由游戏调用的函数，再以这个根函数调用其他的函数，从而实现完整的功能。功能函数入口的概念就来源于此，Main函数中相当于定义了无数个数据包的功能，而功能的具体实现则在它调用的函数中。

函数的标签则是通过FunctionTag特性实现的。它的第一个参数为函数标签的名字，第二个参数是命名空间，可省略，默认为minecraft。上面的例子中设置了函数qwq的标签，因此数据包中会有这样的标签文件：
*data\owo\tags\functions\qwq.json*
```json
{
  "values": [
    "mcsharp_test:test/qwq"
  ]
}
```
