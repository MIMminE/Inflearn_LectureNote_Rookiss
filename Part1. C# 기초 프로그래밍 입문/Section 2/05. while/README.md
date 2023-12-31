# Section 2-5 while

---

## **while 반복문** 

---

> While 반복문은 괄호안의 조건식이 참이면 중괄호 안의 코드를 반복하는 문법이다.

```
int number = 10;

while(number > 0) 
{
	// 반복되는 코드
	// 반복되는 코드
}
```

주의해야할 점은 언제가는 반복문을 나올 수 있도록 설계를 해야 한다는 것이다.

조건식에서 사용된 변수의 값의 변경을 while 반복되는 코드 부분에 집어넣거나,

break 문을 통해 강제로 반복문을 탈출하는 방법이 있다.

```C#
int number = 10;

while(number > 0) 
{
	// 반복되는 코드
	// 반복되는 코드
    
    number--; 
    // 반복될 때마다 number 값을 변경시킨다.
}
```

## **do-while 반복문**

---

> while 문과 같게 조건식에 참이면 반복하는 문법이다.  
> 차이점은 do-while 문은 조건식을 검삭하는 부분이 코드 아래단에 위치하여  
> 무조건적으로 1회 이상의 반복을 보장한다.

```C#
int number = 10;

do
{
	// 반복되는 코드
	// 반복되는 코드
}while(number > 0);
```

조건식이 처음부터 거짓이더라도 do-while문은 1회의 실행을 보장한다.

```C#
int number = 0;

do
{
	//반복하는 코드
}while(number>0);
//조건식이 거짓이지만 1회는 실행된다.
```

> 인프런 Rookiss 강사님 로드맵 'C#과 유니티로 만드는 MMORPG 게임 개발 시리즈'에 대한 학습을 진행하면서 작성한 개인 기록용 강의노트입니다.