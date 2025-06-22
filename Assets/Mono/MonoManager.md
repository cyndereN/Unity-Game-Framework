# MonoManager


## 作用

使不继承MonoBehaviour的类能够开启协程，并且可以使用FixedUpdate、Update、LateUpdate进行每帧更新。

## 原理

1. 在场景中创建一个继承MonoBehaviour的“Executer”脚本，这个脚本就专门用来开启协程和监听帧更新。
2. Mono管理器访问这个“Executer”脚本，就可以实现所需的效果。