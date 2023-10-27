# Section 1.2 SELECT FROM WHERE
## SELECT FROM

데이터베이스 테이블에서 원하는 데이터를 조회하는 명령어이다.

별표(*)를 사용하게 되면 전체 테이블 내의 전체 필드가 선택되며, 원하는 필드가 있을 경우 직접 지정해주면 해당 필드만 조회한다. 

사용할 때 반드시 **`FROM`** 키워드를 이용해서 **어떤 테이블인지를 명시**해줘야 한다.

```sql
SELECT nameFirst AS name, nameLast, birthYear
FROM players;
```

**`AS`** 키워드를 사용하여 필드에 임의로 특정 이름을 부여하여 쿼리 결과를 확인할 수 있다.

💡 **SELECT 사용에 대한 유의점**

사람에게 친숙한 용어를 사용해서 처음보더라도 어느정도 의미를 파악할 수 있게 설계되었긴 하지만 엄연히 따지고 보면 **영어의 실제 어순**을 따르고 있다.

명령어 줄 수가 길지 않을 때는 어렵지 않게 해석하는 것이 가능하지만 길어지면 헷갈리는 부분이 발생할 수 있으므로 어떤 순서대로 작성해야 하는지에 대해 유의깊게 확인하는 것을 권장한다.


### WHERE 절

`SELECT` - `FROM` 이후에 작성하는 명렁어로, 조회에 특정 조건을 거는 역할을 한다. 

**(만약, `WHERE` 절 사용 위치가 올바르지 않는다면 정상적으로 작동하지 않으니 주의)**

```sql
SELECT nameFirst, nameLast, birthYear
FROM players
WHERE birthYear = 1866;
-- '같지 않음'을 표현하는 기호는 != 
```

쿼리를 작성한 이후 명령문 블록을 드래그하여 선택 범위를 지정한 후 실행하게 되면 해당 범위에 해당하는 결과를 보여준다. 이는 간편하게 쿼리 결과를 비교할 때 용이하다.

`WHERE` 절의 비교 대상이 숫자 데이터가 아닌 문자열 데이터라 하더라도 사용방법에는 큰 차이가 없다.

```sql
SELECT nameFirst, nameLast, birthYear, birthCountry
FROM players
WHERE birthCountry = 'USA';
-- '같지 않음'을 표현하는 기호는 != 
```

만약, 하나의 조건이 아니라 여러 개의 조건을 걸고 싶을 때는 논리연산자를 사용하여 작성하면 된다.

```sql
SELECT nameFirst, nameLast, birthYear, birthCountry
FROM players
WHERE birthYear = 1866 AND birthCountry = 'USA';
-- '같지 않음'을 표현하는 기호는 != 
```

💡 **논리연산자의 우선 순위**

논리연산자를 2개 이상 사용하는 경우에는 우선 순위를 잘 생각해가며 작성해줘야 한다. 아래 코드를 보자.

```sql
WHERE nameFirst = 'Bobby' OR birthYear = 1866 AND birthCountry = 'USA';
```

프로그래밍 언어나 SQL 등에서는 일반적으로 같은 논리연산자라더라도 AND가 OR보다 연산 우선순위가 높다. 떄문에 위와 같은 경우는 

1. **nameFirst 필드가 ‘Bobby’ 이거나**
2. **birthYear이 1866이면서 birthCountry가 ‘USA’** 

두 경우에 해당하는 조건을 걸고 있는 것이 된다.


데이터 공간이 비어있음을 나타내는 **NULL** 값이 있다. 해당 값에 대한 조건을 걸 때는 아래와 같이 작성해주면 된다. 

(**테이블 설계 당시 또는 필드 설정에서 ‘Allow Nulls’옵션을 설정하여 빈 값을 허용할지 안할지를 결정할 수 있다)**

```sql
WHERE deathYear IS NULL;

WHERE deathYear IS NOT NULL;
```

문자열을 비교하는 방법 중 ‘=’ 연산자를 사용하면 정확히 일치하는 것만을 탐색한다. 만약, 특정 문자열로 시작하거나 특정 문자 개수 등의 조건을 걸고 싶다면 ‘**`LIKE`**’ 키워드와 ‘`%`’, ‘`_`’ 를 적절하게 사용하여 조건을 걸어주면 된다.

- `%` **키워드 : 임의의 문자열**
- `**_` 키워드 : 임의의 문자 1개**

```sql
SELECT *
FROM players
WHERE birthCity LIKE 'NEW%'
-- birthCity 필드의 값이 NEW로 시작한 모든 문자열인 데이터를 조회한다.

WHERE birthCity LIKE 'NEW_'
-- birthCity 필드의 값이 NEW로 시작하고 문자열이 하나가 뒤에 더 붙는 문자열인 데이터를 조회한다.
```


💡 **참고로 명령어를 소문자로 사용해도 상관 없으며 세미콜론(;)의 경우는 써도 괜찮고 쓰지 않더라도 동작에는 지장없지만, 명령어의 끝을 나타내는 가독성이 추가되므로 쓰는 것을 권장한다.**



```
인프런 Rookiss 강사님 로드맵 'C#과 유니티로 만드는 MMORPG 게임 개발 시리즈'에 대한 학습을 진행하면서 작성한 개인 기록용 강의노트입니다.
```
