# Section 4-9 다형성

> 객체의 메소드 등이 동일한 기능을 서로 다른 방법으로 처리할 수 있는 기능
---
### 가상 함수 virtual 과 override


```c#
class Player
{
    public virtual void Move()
    {
        Console.WriteLine("Player 이동!");
    }
}

class Knight : Player
{
    public override void Move()
    {
        Console.WriteLine("Knight 이동!");
    }
}

class Mage : Player
{
    public override void Move()
    {
        Console.WriteLine("Mage 이동!");
    }
}

```
- 다형성을 활용하기 위해서는 부모 클래스에서 virtual 로 선언된 메소드가 있어야 한다.
- 자식 클래스에서는 virtual 메소드를 override 키워드로 재정의해준다.
---
### 오버라이딩(overriding) vs. 오버로딩(overloading)
- 오버라이딩은 부모 클래스의 메소드의 동작 방법을 변경하여 우선 사용하기 위함이다.
- 오버로딩은 이름은 같지만 파라미터와 타입이 다른 메소드를 중복으로 선언하는 것을 말한다.
---
상속 관계에 있는 클래스들에게 어떤 타입인지에 따라 같은 기능을 여러 방식으로 처리하기 위한 기능

### 다형성 활용하기
```C#
class program
{
    static public void PlayerMove(Player player)
    {
        player.Move();
    }

    static void Main(string[] args)
    {
        Knight knight = new Knight();
        PlayerMove(knight);
    }
}
```
- 부모 클래스를 인자로 입력하는 함수를 작성하여 자식 클래스들을 입력으로 주게 되면 각 자식 클래스에서 오버라이딩 된 함수들이 사용된다.

```C#
class HighKnight : Knight
{
    public override void Move()
    {
        base.Move();
        Console.WriteLine("HighKnight 이동!");
    }
}
```
- 메소드를 완전 대체하는 것이 아닌 상위 메소드에 대한 사용한 이후에 추가적인 동작을 하기 위해서 base 키워드를 사용할 수 있다.
- 자식 클래스를 다시 한번 상속한 새로운 클래스에서도 최상위 클래스의 virtual 메소드에 대한 override 메소드 작성이 가능하다.
- virtual로 사용하는 메소드는 일반적으로 부하가 더 높다.