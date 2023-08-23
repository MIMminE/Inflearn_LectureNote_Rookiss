# Text RPG 강의 노트

> **< Section 3 전체 수강 이후 개별적으로 작성한 코드라 강사님의 코드와 다릅니다! :P >**   
     
> **프로그램 순서도**     
* 직업을 선택 :: Knight, Archer, Mage   
 * 필드 입장 여부 선택
 * 몬스터 랜덤 생성 :: Oak, Skeleton, harpy
 * 전투 돌입 여부 선택 :: (33% 확률로 회피 가능 선택지 제공)
 * 전투 돌입 :: 플레이어와 몬스터 순차적으로 공격
 * 플레이어 승리 시 몬스터 리스폰 및 전투 돌입 여부 선택 반복
 * 플레이어 체력 고갈 시 '패배했습니다' 출력 후 게임 종료  

    
> **프로그래밍 고려 사항**   

* ret, out 한정자 사용해보기  
* 함수 위주의 '절차지향' 프로그래밍 기법으로 작성해보기
* 구조체를 활용해보기  
## 실제 코드
### 함수 위주의 절차지향 프로그래밍 구조
```C#
static void ChoiceClass(ref Player player)                       1️⃣ 플레이어 직업 선택
static void EnterFeild(ref Player player)                        2️⃣ 필드 접속 여부 선택
static void RespawnMonster(ref Player player)                    3️⃣ 몬스터 생성
static void SelectBattle(ref Player player, ref Monster monster) 4️⃣ 전투 돌입 여부 선택
static void Battle(ref Player player, ref Monster monster)       5️⃣ 전투
```  

### 열거형과 구조체의 사용
```c#
        enum ClassType
        {
            None = 0,
            Knight = 1,
            Archer = 2,
            Mage = 3
        }
        enum MonsterType
        {
            None = 0,
            Oak = 1,
            Skeleton = 2,
            harpy = 3
        }

        struct Player
        {
            public int hp;
            public int attack;
            public ClassType class_code;
        }

        struct Monster
        {
            public int hp;
            public int attack;
            public MonsterType monster_code;
        }
```



### while 조건식 응용
```c#
static void Battle(ref Player player, ref Monster monster)
        {
            while(!(monster.hp <= 0 || player.hp <= 0))    
            //1️⃣ "몬스터와 플레이어 중 hp가 0이하로 떨어진 객체가 존재할때"까지 라는 의미로 사용
            {                                               
                monster.hp -= player.attack;
                if (monster.hp > 0)
                {
                    player.hp -= monster.attack;
                    if (player.hp <= 0)
                    {
                        Console.WriteLine("패배했습니다.");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("승리했습니다.");
                    Console.WriteLine($"현재 남은 hp: {player.hp}");
                    break;
                }
            }   
        }


```


> **Comment**
-  한 섹션의 모든 강의의 실습을 합쳐서 복습을 하려니 까먹는 부분들이 있는 것 같다.
-  강의 별로 따로따로 정리해보자.

