# Section 4-2 Collision
## Collision

`Rigidbody` 옵션 중 `Is Kinematic` 옵션을 키게 되면 유니티 물리 엔진의 영향을 받지 않게 된다. 

물체와 충돌을 할 때 발생하는 이벤트를 처리하는 기능을 자주 사용하게 된다. 해당 기능을 사용하기 위해서는 우선 C# 스크립트를 작성해야 한다. 

충돌 이벤트를 처리하는 메소드는 유니티 엔진에서 제공해주고 있으며 아래 두 개의 함수 중 하나를 선택하여 처리해주면 된다., 둘의 처리 방식에는 약간의 차이가 있다.

```csharp
private void OnCollisionEnter(Collision collision)
{
    Debug.Log("Collistion !");
}

private void OnTriggerEnter(Collider other)
{
    Debug.Log("Trigger !");
}
```

`Collision` 같은 경우에는 물리엔진을 켰을 때 어떤 물체에 부딪혀 이동에 방해가 되는 상황에서 발생하는 이벤트이다. 즉, 중력의 영향을 받아 바닥에 닿거나, 앞으로 가다가 `Rigidbody`가 있는 오브젝트에 부딪히거나 하는 상황이다.

`Triger` 같은 경우에는 물리엔진의 영향을 받지 않고 오브젝트들에 스쳐지나갈때 발생하는 이벤트이다. 즉, 물리엔진의 효과를 받지 않기 때문에 물체를 통과할 수 있게 되서 충돌은 발생하지 않지만 그와 비슷한 `Triger`는 발생시킬 수 있다. 

Trigger를 발생시키기 위해서는 `Collider`의 `Is Trigger 옵션`을 켜줘야 한다.

**정리하자면 Collision이 발생하는 경우의 조건은 다음과 같다.**

1. 나 또는 상대방에게 RigidBdoy가 있어야 하며, IsKinematic 옵션은 꺼져 있어야 한다.
2. 나한테 Collider가 있어야 하며, IsTrigger 옵션이 꺼져 있어야 한다.
3. 상대한테 Collider가 있어야 하며, IsTrigger 옵션이 꺼져 있어야 한다.