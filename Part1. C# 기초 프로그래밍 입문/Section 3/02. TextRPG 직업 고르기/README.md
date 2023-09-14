# Section 3-2 TextRPG 직업 고르기

---

## **TextRPG**

---

> 콘솔 창에서의 출력만을 가지고 RPG 스타일의 게임을 개발한다.   
> 여러 직업 중 하나를 선택하면 해당 직업에 알맞는 스탯이 부여되고,  
> 사냥터로 이동하여 몬스터와 전투를 진행하는 간단한 게임이다.

## **직업 선택** 

---

> 직업 종류를 관리하는 열거형 타입을 만들어 관리를 한다. **(ClassType)**  
>   
> 콘솔에 직업 선택에 대한 정보를 출력하고 사용자가 원하는 직업에 해당하는 번호를 입력하여 선택하도록 하는 메소드를 구현하고 Main 에서 해당 메소드를 호출하여 사용한다. **(ChooseClass)  
>   
> **입력이 올바르지 않는다면 직업 선택을 반복하여 시도한다.

### **ClassType**

```c#
public enum ClassType
{
    None,
    Knight,
    Archer,
    Mage
}
```

### **ChooseClass**

```c#
static public ClassType ChooseClass()
{
    Console.WriteLine("직업을 선택하세요");
    Console.WriteLine("[1] 기사");
    Console.WriteLine("[2] 궁수");
    Console.WriteLine("[3] 법사");

    int choose = Convert.ToInt32(Console.ReadLine());

    if (choose >= Enum.GetValues(typeof(ClassType)).Length)
        return ClassType.None;          

    ClassType[] enumArray = (ClassType[])Enum.GetValues(typeof(ClassType));
    return enumArray[choose];
}
```

사용자 입력으로 받은 숫자를 이용하여 열거형 데이터 타입에서 빠르게 데이터를 확인하기위해 사용한 방법이다. 

열거형 타입을 Array구조로 변환하게 되면 숫자 인덱스를 이용하여 접근이 가능해진다.

(물론 열거형을 사용했으므로 switch case 를 사용해도 괜찮다)

```
ClassType[] enumArray = (ClassType[])Enum.GetValues(typeof(ClassType));
return enumArray[choose];
```

### **Main**
```c#
static void Main(string[] args)
{
    ClassType ChooseType = ClassType.None;
    while (ChooseType == ClassType.None)
    {
        ChooseType = ChooseClass();
    }
}
```

올바른 직업 선택(1~3)이 아니라면 계속하여 직업 선택을 요구한다.

> 인프런 Rookiss 강사님 로드맵 'C#과 유니티로 만드는 MMORPG 게임 개발 시리즈'에 대한 학습을 진행하면서 작성한 개인 기록용 강의노트입니다.

