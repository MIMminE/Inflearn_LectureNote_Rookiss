# Section 6-5 Dictionary
***Date : 2023. 08. 21***
> 배열, 리스트 같은 데이터구조는 각 데이터에 대한 고유의 식별자가 없어 인덱스 번호로만 접근이 가능하다.   
> 때문에, 데이터가 많아진다면 데이터 탐색에 오랜 시간이 걸리게 된다.   
> Dictionary는 각 데이터를 나타내는 특정 키 값으로 데이터를 빠르게 찾을 수 있게 해준다.
---
### Dictionary의 선언과 사용
```C#
    class Monster
    {
        static int monsterSerialNum = 0;   
        // static 변수를 이용하여 몬스터 클래스를 이용한 인스턴스 일련번호 관리
        // Section 4-5 static의 정체 내용 활용해보기

        public int monsterId;
        public Monster() { monsterSerialNum++; monsterId = monsterSerialNum; }
        // 생성자로 인해 인스턴스가 생성되면 static 변수의 값을 가져와 일련번호로 사용한다.
    }

    Dictionary<int, Monster> dic = new Dictionary<int, Monster>();

    dic.Add(1, new Monster());
```
- 제너릭 프로그래밍을 이용하여 <키, 값> 형태로 선언한다.
- .Add 메소드를 통해 키와 값을 입력하여 데이터를 생성할 수 있다.

### Dictionary 탐색
```C#
    Monster mon;
    dic.TryGetValue(1, out mon); 

    if (dic.TryGetValue(1, out mon))
    {
        Console.WriteLine(mon.monsterId);
    }
```
- dic[2] 처럼 키 값에 대한 직접적인 탐색도 가능하긴 하지만 해당 키 값의 존재여부에 따라 오류를 발생시킬 수 있다.
- .TryGetValue() 메소드를 이용해 키 값을 이용해 값을 찾아 반환한다.
- .TryGetValue() 메소드는 bool 타입이므로 조건식과 함께 쓰기 편하다.

### Dictionary 삭제
```C#
    dic.Remove(1); // 해당 키 값에 해당하는 Dictionary 삭제
 
    dic.Clear();   // 모든 Dictionary 삭제
```
---
> Dictionary는 해시테이블 알고리즘으로 구현되어 있다. 이는 미리 메모리 공간을  할당하여 사용해야하지만, 탐색 속도를 크게 향상시킨다는 장점을 가진다.  
 ***해시테이블 알고리즘은 따로 공부할 것***