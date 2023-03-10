# UnityParticleSystemMemoryOptimization
主要的思路来源：[unity 特别优化](https://docs.unity.cn/cn/2020.3/Manual/BestPracticeUnderstandingPerformanceInUnity8.html)


## 粒子系统池

对粒子系统建池时，请注意它们至少消耗 3500 字节的内存。内存消耗根据粒子系统上激活的模块数量而增加。停用粒子系统时不会释放此内存；只有销毁粒子系统时才会释放。

从 Unity 5.3 开始，大多数粒子系统设置都可在运行时进行操作。对于必须汇集大量不同粒子效果的项目，将粒子系统的配置参数提取到数据载体类或结构中可能更有效。

需要某种粒子效果时，“通用”粒子效果池即可提供必需的粒子效果对象。然后，可将配置数据应用于对象以实现期望的图形效果。

这种方案比尝试汇集给定场景中使用的粒子系统的所有可能变体和配置会更具内存使用效率，但需要大量的工程努力才能实现。

## 实现思路

就如同 unity 的优化指南所述，我们可以构建一个通用粒子对象池，新增一个类用来存储原始 particle system 的数据，需要的时候把数据应用起来即可。

## 优化效果

65.7M(particle system) -> 16.7M(custom class) + 10.7M(particle system)
