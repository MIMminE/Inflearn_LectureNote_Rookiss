# Section 4-2 복사(값)와 참조

## 클래스와 구조체의 차이
> 구조체는 기본적으로 복사 동작을 기반으로 하고 클래스는 참조를 기반으로 동작한다.

```C#
    class Knight
    {
        public int hp;
        public int attack;
    }
    
    struct Mage
    {
        public int hp;
        public int attack;
    }

    static void KnightKill(Knight knight)
    {
        knight.hp -= 100;
    }

    static void MageKill(Mage mage)
    {
        mage.hp -= 100;
    }
```

1. KnightKill 메소드
    - 클래스로 선언된 knight 객체를 입력으로 받는다.
    - 클래스를 받기 때문에 기본적으로 참조 개념으로 인자를 받는다.
    - knight의 hp속성에 대한 연산이 실제 knight에 적용된다.

2.  MageKill 메소드
    - 구조체로 선언된 mage 객체를 입력으로 받는다.
    - 구조체를 받기 때문에 기본적으로 복사 개념으로 인자를 받는다.
    - Mage의 hp속성에 대한 연산이 실제 mage에 적용되지 않는다.

> BreakPoint를 이용한 디버그 또는 해당 값 출력을 통해 실제로 확인해보기!

#### 클래스와 구조체의 복사 

```c#
    Mage mage;                       
    mage.hp = 100;
    mage.attack = 10;

    Mage mage2 = mage;      // mage2 구조체 인스턴스와 mage 구조체 인스턴스는 완전 분리된 다른 것
    mage2.hp = 70;
```
- 구조체는 복사를 기반으로 하기에 mage2에 mage를 저장하는 방식은 모든 값을 그대로 전달하여 같은 값을 가진 또 다른 구조체를 만들어내는 것이다. 
- 이와 같은 복사의 개념을 '깊은 복사'라고 한다.


```c#
    Knight knight = new Knight();
    knight.hp = 100;
    knight.attack = 10;

    Knight knight2 = knight;     
    // 클래스는 참조 베이스로 동작하므로 knight2는 knight이 가리키고 있는 것과 같은 것을 가리키게 된다.
```
- 클래스는 참조를 기반으로 하기에 위와 같은 코드를 사용할 경우, 같은 주소를 가리키게 되고 두 인스턴스에 대한 변경은 실제 하나의 값의 변경을 공유하게 된다.
- 이와 같은 복사의 개념을 '얇은 복사'라고 한다.
- 얇은 복사의 경우 의도치 않게 실제 값을 변경하게 될 수 있으므로 주의가 필요하다.



> 클래스에 특정 메소드를 구현함으로써 클래스의 깊은 복사 기능을 메소드화 할 수 있다.
```c#
public Knight Clone()
{
    Knight cloneKnight = new Knight();
    cloneKnight.hp = hp;
    cloneKnight.attack = attack;
    return cloneKnight;
}
```




####추가 사항 :
구조체의 복사를 항상 깊은 복사라고 보는 것은 위험해 보이기도 한다. 
만약, 구조체의 멤버 변수로 참조 형식을 취하고 있다면 해당 구조체의 복사로 인해
부분 적으로 얇은 복사가 발생할 수도 있기 때문이다. 
