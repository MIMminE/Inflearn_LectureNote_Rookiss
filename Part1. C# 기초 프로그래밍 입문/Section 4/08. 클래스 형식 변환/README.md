# Section 4-8 클래스 형식 변환

> 변수의 형변환과 같이 클래스 간에도 형변환이 가능하다.  
> 하지만 제한적인 부분들이 있어서 신중하게 해야한다.  

---

### 자식 클래스 -> 부모 클래스로의 형식 변환
```C#
class Player
{
    public int hp;
    public int attack;
}

class Knight : Player
{}

class Mage : Player
{}

public void ShowInfo(Player player)
{
    Console.WriteLine($"{player.hp}, {player.attack}");
}

class program
{
    static void Main(string[] args)
    {
        Knight knight = new Knight();  
        ShowInfo(knight);   

        Mage mage = new Mage();
        ShowInfo(mage);
    }
}

```
- Player 클래스를 부모 클래스로 둔 Knight 클래스와 Mage 클래스는 Player 클래스를 입력으로 받는 메소드의 인자로 사용할 수 있다. 
- 이는 모든 자식 클래스는 부모 클래스의 특성을 모두 갖고 있기 때문에 형태 변환을 하더라도 문제가 발생하지 않는다.
- 반대 경우인 부모 클래스에서 자식 클래스로의 형태 변환은 문제가 발생할수도, 그렇지 않을수도 있다.


### 부모 클래스 -> 자식 클래스로의 형태 변환 

```C#
class program
{
    static void Main(string[] args)
    {
        Knight knight = new Knight();       // 객체 생성
        Player knight2 = knight;            // 자식 클래스 -> 부모 클래스 형태 변환
        Knight knight3 = (Knight)knight2;   // 부모 클래스 -> 자식 클래스 형태 변환 
    }
}
```
- 일반적으로 부모 클래스 -> 자식 클래스 형태 변환은 에러를 발생시키지만 명시적으로 캐스팅을 해주면 가능하다.
- 부모 클래스 -> 자식 클래스 형태 변환은 문제를 발생시킬수도 있으므로 캐스팅을 요구하는 것이다.

---
### 부모 클래스 형태 변환을 이용한 메소드 이용
```C#
public void ShowInfo(Player player)
{
    Console.WriteLine($"{player.hp}, {player.attack}");
}
```
- 부모 클래스를 입력으로 받게 되면 자식 클래스들을 입력으로 줄 수 있다.
- 하지만 자식 클래스의 내용을 가져와서 사용할 수는 없기에 한계가 있다.

---
### 클래스 변환에서의 is 연산자 (as 연산자)
```c#
static public void ShowInfo(Player player)
{
    bool isMage = (player is Mage);
    if (isMage)
    {
        Mage mage = (Mage)player;
        Console.WriteLine($"mp:{mage.getMp()}");    
    }
    else if(player is Knight) 
    { 
        Knight knight = (Knight)player;
        Console.WriteLine($"str:{knight.getStr()}");
    }
}
```
- is 연산자를 통해 해당 객체의 타입 검사를 할 수 있다. 
- player 부모 클래스로 인자를 받았지만 본래 클래스의 모습에 따라 기능을 나눠 사용하고 있다.

```C#
static public void ShowInfoVer2(Player player)
{
    Mage mage = player as Mage;
    Knight knight = player as Knight;  
    if (mage != null)
    {
        Console.WriteLine($"mp :: {mage.getMp()}");
    }
    else if (knight  != null)
    {
        Console.WriteLine($"str :: {knight.getStr()}");
    }
}
```
- as 연산자를 사용하여 같은 기능을 하는 메소드이다. 
- bool 타입을 반환하는 is 연산자와 달리 해당 클래스 객체로 반환하는 것이 차이점이다.