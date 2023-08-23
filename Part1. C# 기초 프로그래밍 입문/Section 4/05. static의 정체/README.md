# Section 4-5 static의 정체

> static은 클래스에 종속적인 필드 또는 메소드를 생성할 때 사용되는 키워드이다.  
static를 사용하지 않은 필드 또는 메소드는 생성된 각 인스턴스에 종속된다.

---

```c#
class Knigth
{
    static public int counter = 1; // 오로지 1개만 존재할 수 있다.

    public int id;
    public int hp;
    public int attack;
}
```
위와 같이 static으로 생성된 필드가 있다면 해당 필드는 클래스 전체에서 오로지 한 개만 존재할 수 있다. 즉, 클래스 생성자를 통해 여러 객체가 생성된다 하더라도 해당 필드는 생성되지 않는다.  
*< 이는 static으로 선언된 메소드도 마찬가지다. >*

```C#
public Knigth()
{
    id = counter; // static 필드의 값을 가져와서 필드 값을 설정한다.
    counter++;    // static 필드에 접근하여 값을 변경해 줄 수 있다.

    hp = 100;
    attack = 10;
    Console.WriteLine($"기본 생성자입니다. id번호는 {id}");
}
```
- 위와 같은 생성자를 사용하여 객체를 생성한다면, 객체가 생성될 때마다 counter 정적 필드의 값이 증가하게 된다.
- 결과적으로 객체 생성이 진행됨에 따라 각 객체는 생성 순서에 따라 고유 번호를 얻는다.

```C#
static public void PlusConuter()
{
    counter++;
}
```
- static 으로 선언된 메소드의 경우에는 해당 클래스에 종속되어 사용된다.

```c#
    Random rand = new Random();
    rand.Next();
    //위와 같이 객체를 생성하고 사용하는 메소드의 경우에는 static이 아니다.
    Concole.WriteLine();
    //반면 위와 같이 클래스 자체의 메소드를 사용하는 경우가 static이다.
```
---
### static 으로 선언된 메소드는 일반 필드로 접근이 일반적으로는 불가능하다.
```C#
static public Knigth CreateKnight()
{
    this.hp = 100; // 해당 코드는 에러를 발생시킨다. 

    Knigth knigth = new Knigth();
    knigth.hp = 100;
    knigth.attack = 10;
    return knigth;
}
```
- static으로 선언된 메소드에서는 자기 자신을 뜻하는 this 키워드 자체가 사용이 불가능하다.
- 위와 같은 static 메소드는 내부에서 생성된 knight 객체로의 접근이라 가능하다.