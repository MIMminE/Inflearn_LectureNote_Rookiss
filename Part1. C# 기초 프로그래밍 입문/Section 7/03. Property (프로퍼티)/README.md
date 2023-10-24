# Section 7-3 Property (프로퍼티)

### 객체지향 언어의 은닉성
- 대부분의 객체지향 언어에서는 클래스의 은닉성을 보장하기 위해 private, protected 엑세스 한정자를 사용한다.
- 멤버 변수의 접근을 제한하고 해당 변수에 대한 조작을 담당하는 함수를 구현하여 해당 함수들로 조작을 하게 된다. 이것을 일반적으로 Get함수, Set함수라 한다.
- 멤버 변수의 접근을 제한하고 함수를 이용하여 조작하는 것은 대규모 프로젝트에서의 실수 방지와 호출 스택을 이용한 디버그 분석에 유용하다.
- Get함수와 Set함수 내부에서 조건을 걸어 특정 환경에서만 값의 변경을 허용하거나 하는 로직도 자주 사용된다. (ex : 몬스터가 무적이 아닐 경우에만 hp를 변경할 수 있도록 설계)
    ```C#
    public void SetHp(int hp)
    {
        if (status != Status.Invincible)
        {
            _hp = hp;
        }
        else
        {
            Console.WriteLine("무적상태입니다.");
        }
    }
    ```
---

### Property 
- 클래스의 멤버변수가 많아지면 get함수와 set함수가 많아져 관리가 어려워질수도 있다.
- C#에서는 이를 위해 Property 문법을 지원하여 생성과 사용에 있어 편리함을 제공한다.
  ```C#
    private int _typeNumber;

    public int typeNumber
    {
        get { return  _typeNumber; }
        set { this._typeNumber = value; } // value 변수는 프로퍼티의 기본 매개변수
    }
  ```
- public 으로 공개되어 있는 멤버변수에 접근하는거와 동일하게 사용이 가능하다. 하지만 동작은 함수처럼 동작하기에 은닉성과 디버그에서의 이점을 그대로 가져간다.
  ```c#
  static void Main(string[] args)
  {
    type.typeNumber = 1; //set 기능
    Console.WriteLine(type.typeNumber); //get 기능
  }
  ```
  
- 더 간략하게 표현이 가능하다. (자동구현 Property)
   ```c#
    public int typeNumber2 { get; set; } = 100; // C# 7.0부터 사용 가능한 초기화 기능
   ```
   - 자동구현 Property를 사용하면 매개변수의 생성까지 자동으로 컴파일러가 자동으로 한다.
