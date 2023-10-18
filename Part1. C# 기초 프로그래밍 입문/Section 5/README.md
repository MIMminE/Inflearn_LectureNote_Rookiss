# Section 5 TextRPG2 
> Section 3에서 만들었던 TextRPG를 객체지향 기법으로 새롭게 만들기  
---
### 유의사항
   - 몬스터와 플레이어 구성에 있어 객체지향의 상속,다형성,은닉성을 신경쓰며 작성할 것.
   - 직접 고르기, 플레이어 생성, 필드 이동, 몬스터 생성, 전투 기능 구현할 것
   - 클래스 별 파일 나눠서 관리할 것
   - 먼저 만들어보고 강사님 코드와 비교해보기!

---
### 클래스 구성 
- 두 개의 최상위 클래스를 둔다.  
  + Creature : 생명체 개념을 가진 객체들의 속성을 다루는 최상위 클래스
  + Field : 맵 개념을 가진 객체들의 속성을 다루는 최상위 클래스   
  

### Creature 클래스
```C#
class Creature
{
    protected int hp;
    protected int damage;
    protected bool alive;

    public static void Battle(Creature battleCreature1, Creature battleCreature2);
    public virtual void Attack(Creature target) { }
    protected void Die();
    public void Damage(int inputDamgage);
    public bool GetAlive();
}
```
- 자식 클래스로 Player 와 Monster 를 가지며 활동하는 생명체들의 생존, 전투 등을 관리하기 위해 설계했다.
- 부모 클래스에서 전투와 공격, 죽음 등의 기능을 구현함으로 자식 클래스들도 자연스레 가지게 되어 몬스터 vs 몬스터, 플레이어 vs 플레이어 등의 배틀도 손 쉽게 구현할 수 있었다.

## Monster 클래스
```C#
class Monster : Creature
{
    static public Monster CreateMonster()
    {
        Monster monster = null;
        Random rand = new Random();
        int randValue = rand.Next(1, 4);

        switch (randValue)
        {
            case 1:
                Console.WriteLine("Orc가 생성되었습니다.");
                monster = new Orc();
                break;
            case 2:
                Console.WriteLine("Skeleton가 생성되었습니다.");
                monster = new Skeleton();
                break;
            case 3:
                Console.WriteLine("Harpy가 생성되었습니다.");
                monster = new Harpy();
                break;
            default:
                break;
        }
        
        return monster;
    }
}
```
- Creature 클래스를 상속받은 Monster 클래스에서 랜덤 몬스터 생성을 위해 static 함수를 사용했다.

## Player 클래스
```C#
class Knight : Player
{
    public Knight() : base(150, 8) { }
    public Knight(int hp, int damage) : base(hp, damage) { }
    public override void Attack(Creature target)
    {
        base.AttacksNum(target, 2);
    }
}

class Mage : Player
{
    public Mage() : base(100, 30) { }
    public Mage(int hp, int damage) : base(hp, damage) { }
    public override void Attack(Creature target)
    {
        base.AttacksNum(target, 1);
    }
}
```
- 다형성을 사용해보기 위해 각 클래스의 공격 횟수를 다르게 사용했다.

## Field 클래스
#### Lobby 클래스
```C#
class Lobby : Field
{
    public Lobby() : base(false) { }
    public override void EnterField()
    {
        base.EnterField();
        Console.WriteLine("로비에 입장했습니다.");
    }
    public override Player ProcessField()
    {
        Player player = null;
        Console.WriteLine("직업을 선택하세요\n[1]Knight \n[2]Mage \n[3]Archer");
        string input = Console.ReadLine();
        switch (input)
        {
            case "1":
                player = new Knight();
                break;
            case "2":
                player = new Mage();
                break;
            case "3":
                player = new Archer();
                break;
            default:
                break;
        }
        return player;
    }
}
```
- 각 맵에서 발생하는 동작들을 구현할 생각으로 만든 클래스이다. 로비에서 캐릭터를 생성하는 로직을 만들어 Player타입으로 리턴했다. 이를 통해 여러 클래스로 나누어진 하위 직업들을 관리하기 편했다.
- 다형성을 최대한 활용해보기 위해 여러 오버라이딩을 사용해보았다. (그런데 return 타입이 다르거나 매개변수를 넣었으면 하는 부분이 생기면서 완벽하게 사용해보진 못한거 같다. 다형성은 같은 목적을 위해 사용되어야 한다는걸 명심해야 할듯하다.)

### 

## Game 클래스
```C#
class Game
{
    private Lobby lobby;
    private BattleField battleField;
    private Town town;
    private Player player;

    public Game()
    {
        lobby = new Lobby();
        battleField = new BattleField();    
        town = new Town();

        player = lobby.ProcessField();
        player.ShowInfo();
    }
    public void StartGame()
    {
        town.EnterField();
        town.ProcessField();
        battleField.EnterField();
        while (player.GetAlive())
        {
            battleField.ProcessField(player);
        }
    }
}
```
- 게임 실행을 제어하기 위해 설계한 클래스이다.
- 맵과 플레이어 등 게임 플레이에 기억되어야 할 데이터들을 멤버변수에 넣어 가져와 사용하기


---
> 구현하면서 초기 설계와 조금씩 달라지면서 코딩에 어려움을 겪었는데, 역시.. 설계 단계에서부터 조금 더 꼼꼼하게 볼 필요가 있어보인다.  
> 그리고 각 기능들을 어떤 클래스에 구현해야 좋을 지에 대한 기준도 아직 잡기 어려운 것 같다.  
> 전투 시작하는 기능이나 몬스터를 생성하거나 캐릭터를 생성하는 기능을 어떤 클래스에 줘야할 지 등등..
 