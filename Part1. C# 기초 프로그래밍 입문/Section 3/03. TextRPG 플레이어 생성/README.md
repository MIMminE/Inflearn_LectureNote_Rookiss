# Section 3-3 TextRPG 플레이어 생성
---

> **사용자가 선택한 클래스 타입에 맞춰 플레이어의 스탯을 정해주려고 한다. 직업별 스탯은 아래처럼 설정한다.**  
>   
> 
> | **classType** | **hp** | **attack** |
> | --- | --- | --- |
> | Knight | 100 | 10 |
> | Archer | 75 | 12 |
> | Mage | 50 | 15 |
> 
>   
> 이전 수업에서 작성한 아래 코드에 이어서 작성한다.

```C#
static void Main(string[] args)
{
    ClassType chooseType = ClassType.None;
    while (chooseType == ClassType.None)
    {
        chooseType = ChooseClass(); // 콘솔 창에서 사용자가 직접 직업 선택
        //코드 작성 위치
    }
}
```

## **out 키워드를 사용한 플레이어 생성**

---

### **out 키워드를 매개변수로 받는 함수 작성**

```C#
static void CreatePlayer(ClassType classType, out int hp, out int attack)
{
    switch(classType)
    {
        case ClassType.Knight:
            hp = 100;
            attack = 10;
            break;
        case ClassType.Archer:
            hp = 75;
            attack = 12;
            break;
        case ClassType.Mage:
            hp = 50;
            attack = 15;
            break;
        default:
            hp = 0;
            attack = 0;
            break;
    }
}
```

> out 키워드를 이용하게 되면 해당 매개변수의 입력은 참조 타입으로 사용하게 된다.   
> 즉, 원본 데이터의 메모리에 직접 접근하여 값을 변경하게 된다.  
> **결과적으로 사용자가 입력한 클래스에 따라 스탯이 결정된다.**  
>   
> 함수 호출에서 해당 out 키워드 매개변수 입력 시 out 키워드 사용하여 입력해주어야 한다.

### **함수 호출**

```C#
static void Main(string[] args)
{
    ClassType chooseType = ClassType.None;
    while (chooseType == ClassType.None)
    {
        chooseType = ChooseClass();
        if(chooseType != ClassType.None)
        {
         ✅   int hp;
         ✅   int attack;
         ✅   CreatePlayer(chooseType, out hp, out attack);
        }
    }
}
```

> 1\. 플레이어의 스탯을 표현하기 위한 변수 생성(hp, attack)  
> 2\. 사용자가 선택한 직업(chooseType), out 키워드를 이용해 참조 타입으로 인자 입력

## **구조체를 사용한 플레이어 생성**

---

### Player 구조체 선언

```C#
struct Player
{
    public int hp;
    public int attack;
}
```

> 구조체는 여러 데이터 타입을 하나로 묶어 사용자 정의 데이터 타입을 만드는 문법이다.  
> Player 타입으로 선언한 변수는 int 타입의 hp와 attack에 대한 공간을 가진채로 생성된다.

### **구조체를 이용한 함수 작성**

```C#
static void CreatePlayer(ClassType classType, ✅ out Player player)
{
    switch(classType)
    {
        case ClassType.Knight:
            player.hp = 100;
            player.attack = 10;
            break;
        case ClassType.Archer:
            player.hp = 75;
            player.attack = 12;
            break;
        case ClassType.Mage:
            player.hp = 50;
            player.attack = 15;
            break;
        default:
            player.hp = 0;
            player.attack = 0;
            break;
    }
}
```

> Player 구조체를 입력으로 받았기에 해당 인스턴스(구조체 타입의 변수를 가리키는 용어)를 통해 변수에 접근하여 값을 입력해준다.  
> out 키워드는 여전히 사용중이므로 특별히 반환해주지 않더라도 괜찮다.   
>   
> 만약, 반환을 하기 위해서는 함수의 타입을 Player 타입으로 해주고 반환하면 된다.  
> (그럴경우에는 out 키워드를 사용하지 않아야 하며, out 키워드는 최대한 사용을 하지 않는것이 안전하다)

### **함수 호출**

```C#
static void Main(string[] args)
{
    ClassType chooseType = ClassType.None;
    while (chooseType == ClassType.None)
    {
        chooseType = ChooseClass();
        if(chooseType != ClassType.None)
        {
	     ✅   Player player;
         ✅   CreatePlayer(chooseType, out player);
        }
    }
}
```

> 구조체를 사용하게 되면서 변수를 그룹화하여 관리하고 넘겨주기에 편리하다.  
> 또한, 변수가 추가되어도 구조체 내부에서 추가해주면 되기에 유지보수에 유리하다.

> 인프런 Rookiss 강사님 로드맵 'C#과 유니티로 만드는 MMORPG 게임 개발 시리즈'에 대한 학습을 진행하면서 작성한 개인 기록용 강의노트입니다.