# Section 3-4 TextRPG 몬스터 생성

> 플레이어가 필드에 접속하면 랜덤으로 몬스터가 생성된다. 몬스터 스탯은 아래처럼 설정한다.  
>   
> 
> | MonsterType | hp | attack |
> | --- | --- | --- |
> | Slime | 20 | 2 |
> | Orc | 40 | 4 |
> | Skeleton | 50 | 3 |

## **Monster 열거형과 구조체**

---

> 몬스터 관리를 위해 열거형과 구조체를 생성한다. (이전 시간까지 진행한 플레이어 관리와 유사하다)

```C#
public enum MonsterType
{
    None = 0,
    Slime = 1,
    Orc = 2,
    Skeleton = 3
}

struct Monster
{
    public int hp;
    public int attack;
}
```

나중에 알게된 사실인데, 열거형은 기본적으로 int 타입으로 매칭할 수 있다고도 한다. 

즉, 아래와 같이 사용할 수 있다.  (실습할 때는 이걸 생각치 않고 다른 방식으로 구현했다...)

```
MonsterType mon = (MonsterType)1;
//mon 변수에는 Slime이 저장된다.
```

## **out 키워드를 사용한 몬스터 랜덤 생성**

---

> 몬스터를 랜덤으로 생성하여 out 키워드로 몬스터 객체를 생성해내는 로직을 구현한다.
> 
```C#
Random random = new Random();
MonsterType[] monsterTypeValuse = (MonsterType[])Enum.GetValues(typeof(MonsterType));
MonsterType randMonsterType = monsterTypeValuse[random.Next(1, 4)];
```

C#에서 제공하는 난수 생성 라이브러리를 사용하여 MonsterType 열거형의 유효한 (1~3) 몬스터 타입을 랜덤하게 선택한다. 

```C#
switch (randMonsterType)
{
    case MonsterType.Slime:
        Console.WriteLine("슬라임이 스폰되었습니다.");
        monster.attack = 2;
        monster.hp = 20;
        break;

    case MonsterType.Orc:
        Console.WriteLine("오크가 스폰되었습니다.");
        monster.attack = 4;
        monster.hp = 40;
        break;

    case MonsterType.Skeleton:
        Console.WriteLine("스켈레톤이 스폰되었습니다.");
        monster.attack = 3;
        monster.hp = 50;
        break;
    default:
        monster.hp = 0;
        monster.attack = 0;
        break;

}
```

switch 분기문과 랜덤으로 선택한 열거형 값을 이용하여 monster 객체의 값을 할당해준다. 

_(switch 분기문은 상수(const) 속성을 가진 변수들만 사용할 수 있으며, 열거형도 상수로 취급한다는 걸 기억하자!)_

```C#
static void CreateRandomMonster(out Monster monster)
{
    Random random = new Random();
    MonsterType[] monsterTypeValuse = (MonsterType[])Enum.GetValues(typeof(MonsterType));
    MonsterType randMonsterType = monsterTypeValuse[random.Next(1, 4)];

    switch (randMonsterType)
    {
        case MonsterType.Slime:
            Console.WriteLine("슬라임이 스폰되었습니다.");
            monster.attack = 2;
            monster.hp = 20;
            break;

        case MonsterType.Orc:
            Console.WriteLine("오크가 스폰되었습니다.");
            monster.attack = 4;
            monster.hp = 40;
            break;

        case MonsterType.Skeleton:
            Console.WriteLine("스켈레톤이 스폰되었습니다.");
            monster.attack = 3;
            monster.hp = 50;
            break;
        default:
            monster.hp = 0;
            monster.attack = 0;
            break;

    }
}
```

> 인프런 Rookiss 강사님 로드맵 'C#과 유니티로 만드는 MMORPG 게임 개발 시리즈'에 대한 학습을 진행하면서 작성한 개인 기록용 강의노트입니다.