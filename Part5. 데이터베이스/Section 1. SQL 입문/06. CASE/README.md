# Section 1.5 CASE
## CASE 문법


C#의 **Switch - Case 문법**과 동일한 기능이다.

CASE 키워드 뒤에 등장하는 필드명은 타겟이 되는 필드명으로 해당 값에 따라 결과를 분기한다.

나머지 기능은 직관적으로 확인할 수 있을 만큼 어렵지 않게 구성되어져 있다.

```sql
SELECT 
		CASE birthMonth
				WHEN 1 THEN N'겨울'
				WHEN 2 THEN N'겨울'
				WHEN 3 THEN N'봄'
				WHEN 4 THEN N'봄'
				WHEN 5 THEN N'봄'
				WHEN 6 THEN N'여름'
				WHEN 7 THEN N'여름'
				WHEN 8 THEN N'여름'
				WHEN 9 THEN N'가을'
				WHEN 10 THEN N'가을'
				WHEN 11 THEN N'가을'
				WHEN 12 THEN N'겨울'
				ELSE N'몰라요'
		END AS birthSeason
FROM players;
```

또 다른 사용법으로는 타겟이 되는 필드에 직접 조건을 걸어주는 방법이 있다.

```sql
SELECT 
		CASE 
				WHEN birthMonth <= 2 THEN N'겨울'
				WHEN birthMonth <= 5 THEN N'봄'
				WHEN birthMonth <= 8 THEN N'여름'
				WHEN birthMonth <= 12 THEN N'가을'
				ELSE N"겨울'
		END AS birthSeason
FROM players;
```

C#으로 치면 if-elseif 문법과 유사하게 동작한다.

위 코드의 조건이 맞는다면 아래 코드는 확인하지 않는 특징이 있다.

만약 ELSE 구문이 없는 상태에서 조건이 맞지 않은 값이 있다면 NULL값이 들어가게 된다. NULL이 들어가지 않게 조심하게 사용하거나 NULL 조건을 걸어 처리한다.

```sql
WHEN birthMonth is NULL THEN N'몰라요'
```


```
인프런 Rookiss 강사님 로드맵 'C#과 유니티로 만드는 MMORPG 게임 개발 시리즈'에 대한 학습을 진행하면서 작성한 개인 기록용 강의노트입니다.
```
