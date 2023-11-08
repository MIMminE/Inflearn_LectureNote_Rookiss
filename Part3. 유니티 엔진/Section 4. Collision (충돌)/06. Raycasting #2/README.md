# Section 2-5 Input Manager
## 이벤트를 이용한 키보드 입력 처리


게임 오브젝트를 키보드 입력에 따라 이동시키는 동작은 각 오브젝트 스크립트의 Update 메소드에 작성해주면 된다. 이런 방식은 규모가 작은 프로젝트에서는 큰 문제가 없으나 규모가 조금 커지거나 유지보수 측면에서는 관리가 어려워진다. 

```csharp
public class Player : MonoBehaviour
{
	float _speed = 10.0f;
	void Update()
	{
			if (Input.GetKey(KeyCode.W))
			{
				transform.rotation = Quaternion.Slerp(transform.rotation, 
                Quaternion.LookRotation(Vector3.forward), 0.2f);
				transform.position += Vector3.forward * Time.deltaTime * _speed;
			}
			
			if (Input.GetKey(KeyCode.S))
			{
				transform.rotation = Quaternion.Slerp(transform.rotation, 
                Quaternion.LookRotation(Vector3.back), 0.2f);
				transform.position += Vector3.back * Time.deltaTime * _speed;
			}
	}
}
```

이러한 관리를 매니저 클래스에 등록하여 관리한다면 유지보수가 측면에서 이점이 있다. 핸들러 프로그램을 올려두어 키 입력이 발생할 때 이동하라는 동작을 호출하면 되는 것이다. 이렇게 하면 각 오브젝트의 Update 메소드가 처리해야할 코드가 줄어들어 성능 측면에서도 강점을 가진다.

먼저 키보드 입력이 발생했음을 감지하는 핸들러를 작성해야 한다. 해당 핸들러를 가지고 있는 클래스는 오브젝트의 컴포넌트로써 작동하는 것이 아닌 Manager 클래스의 멤버변수로 사용될 것이므로 `MonoBehaviour 클래스`의 상속을 받지 않는다.

```csharp
public class InputManager
{
	public Action KeyAction = null; 

	public void Onupdate()
	{
		if (Input.anyKey == false)
			return;

		if (KeyAction != null)
			KeyAction.Invoke();
	}
}
```

`Action`은 `delegate`의 일종으로 **반환값이 없는 메서드를 가리킬 때 사용되는 대리자**이다. 대리자에 메소드를 등록하고 있다가 `Invoke 메소드`를 통해 **콜백 구조**로 메소드를 정의할 수 있다. 

MonoBehaviour 클래스를 상속받지 않음으로써 유니티 컴포넌트가 될 수 없고, 그에 따라 오브젝트에 할당될수도 없으니 new 연산자를 통해 인스턴스를 생성해야 사용이 가능하다. (static 실험.)

이전에 준비해두었던 `Manager 클래스`의 멤버변수로 등록한다. 

```csharp
public class Manager : MonoBehaviour
{
    static Manager s_instance; //유일성을 보장한다.
    static Manager Instance { get { init(); return s_instance; } }

    static InputManager s_inputManager = new InputManager();
    public static InputManager Input {get { init();  return s_inputManager; }}
}

void Update()
{
    _inputManager.Onupdate();
}
```

매니저 클래스는 Singleton 구조로 작성되어 단 하나의 인스턴스만을 생성하고 관리되게 설계되어있다. 때문에 해당 클래스의 일반 멤버변수는 사실상 단 하나밖에 생성될 수 없다. 즉 static 없이 선언해도 상관없다는 것이다. 

입력을 발생하면 호출하여 사용할 기능이 있는 컴포넌트에서는 이제 매니저의 입력 핸들러에 해당 함수를 등록해두기만 하면 된다. 

본래 Update 메소드에 있는 키보드 입력 처리 로직을 따로 메소드로 옮겨 해당 메소드를 입력 핸들러에 등록한다.

```csharp
void OnKeyboard()
{
		if (Input.GetKey(KeyCode.W))
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, 
            Quaternion.LookRotation(Vector3.forward), 0.2f);
			transform.position += Vector3.forward * Time.deltaTime * _speed;
		}
		
		if (Input.GetKey(KeyCode.S))
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, 
            Quaternion.LookRotation(Vector3.back), 0.2f);
			transform.position += Vector3.back * Time.deltaTime * _speed;
		}
}
```

유니티가 실행될 때 한번 실행되는 Start 메소드에 등록하고자 하는 함수를 등록하는데, 그 앞에서 등록을 해제하는 부분은 **이미 같은 메소드가 등록되어 있는데 중복으로 등록하는 것을 방지하기 위함이다.**

```csharp
void Start()
{
	Manager.Input.KeyAction -= OnKeyboard;
	Manager.Input.KeyAction += OnKeyboard;
}
```


💡 **이벤트 등록 시기 (Start에서 등록을 해주는 이유)**

```csharp
if (KeyAction != null)
	KeyAction.Invoke();
```

이벤트 핸들러를 구현하는 여러 타입들은 등록된 이벤트가 없다면 `null 값`을 가지게 된다. 위의 코드는 **핸들러에 아무것도 등록되어 있지 않다면 이벤트가 발생하더라도 콜백할 메소드가 없으므로 아무 일도 발생하지 않는다.** 

유니티가 시작될 때 모든 오브젝트의 스크립트 컴포넌트는 `Start`를 실행한 이후 `Update`를 반복한다. 오브젝트가 키보드 입력과 관련된 기능을 처음부터 가지고 시작해야한다면 Start 부분에 넣어주는 것이 일반적이다. 그렇지 않고 중간이나 특정 조건 이후에나 키보드 입력에 반응해야 한다면 Update 문을 통한 중간 로직 단계에서 핸들러에 등록해주면 된다. 
