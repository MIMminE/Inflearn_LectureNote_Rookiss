# Section 4-4 생성자

> 클래스로 객체를 생성하자마자 초기화를 함께 해주는 기법을 '생성자'라고 한다.   

---
### 클래스 생성자 사용법
1. 클래스의 생성자를 만들어줄 떄는 반환 타입을 쓰면 안되고, 클래스 이름과 같게 설정해야한다.
2. 클래스의 인자를 추가하여 여러가지 버젼으로 생성자를 생성할 수 있다.
3. 클래스 멤버 변수와 생성자 매개 변수의 이름이 같을 때 this 키워드를 사용하여 구분한다.


```c# 
class Knight
{
    public int hp;
    public int attack;

    public Knight() // 기본 생성자이다. new Knight(); 실행할 경우 해당 생성자로 객체 생성
    {
        hp = 100;
        attack = 10;
        Console.WriteLine("기본 생성자입니다!"); 
    }

    public Knight(int hp) : this() 
    // int 타입 인자 hp를 받는 생성자
    // new Knight(50)과 같이 int 타입 인자 하나를 줄 경우 해당 생성자로 객체 생성
    {
        this.hp = hp;
        Console.WriteLine("hp 생성자입니다!");
    }
    
    public Knight(int hp, int attack) : this(hp)
    // int 타입 인자 hp와 attack를 받는 생성자
    // new Knight(50, 10)과 같이 int 타입 인자 둘을 줄 경우 해당 생성자로 객체 생성
    {
        this.attack = attack;
        Console.WriteLine("hp, attack 생성자입니다!");
    }
}

```
---
```c#
    public Knight(int hp, int attack) : this(hp)
```
- this 연산자는 자기 자신을 의미하는 키워드로 해당 키워드 호출 시 hp 인자를 넣은 생성자를 먼저 호출하는 기능을 한다.
- 이러한 기능은 기본 생성자의 기능을 항상 써야하지만 필요에 따라 객체의 값을 다르게 해줄 때 유용하게 사용될 수 있다.
- 본 예시에서는 hp, attack를 가진 생성자가 hp만 가진 생성자를 호출하고, hp만을 가진 생성자가 기본 생성자를 호출하는 방식으로 작동한다.
---
#### 추가 내용
- 클래스 상속에서 사용되는 : 연산과 비슷하게 사용되고 있지만 '생성자 체이닝' 이라는 기법이다.
