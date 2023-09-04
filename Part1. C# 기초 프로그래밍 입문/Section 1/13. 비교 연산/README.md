# Section 1-13 비교 연산


## 비교 연산자
같다, 크거나 같다, 크다, 작거나 같다 등의 비교 조건에 대한 연산자들이다.  
결과로는 bool 자료형의 true 또는 false를 반환하다.

```C#
    // 비교 연산자의 결과가 isAlive 타입으로 반환된다.

    int hp = 100;
    bool isAlive = (hp > 0); 
    // hp가 0보다 크면 True, 그렇지 않으면 False

    int level = 10;
    bool canEnterDungeon =  (level <= 5);
    // level 이 0보다 작거나 같으면 True, 그렇지 않으면 False

    int maxHp = 100;
    bool fullHp = (hp == maxHp);
    // maxHp와 hp가 같으면 True, 그렇지 않으면 False
```


