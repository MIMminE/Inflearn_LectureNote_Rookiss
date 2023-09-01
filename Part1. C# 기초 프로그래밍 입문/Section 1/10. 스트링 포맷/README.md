# Section 1-10 스트링 포맷

> 기본 데이터 타입 중 string은 클래스에 해당하며 일반 캐스팅이 아닌 다른 방법을 통해 변환이 가능하며  
 '스트링 포맷'과 '스트링 인터폴레이션'문법이 그에 해당한다.


## string -> int 변환
```C#
    string input;
    input = Console.ReadLine(); //string 타입으로 반환되는 메소드
    input = input + 1; // 에러 발생
```
ReadLine 메소드는 콘솔 창에서 키보드 입력을 기다리게 되는데, 숫자가 입력되더라도 해당 값을 문자로 받아들인다.   
때문에, 덧셈 연산에 에러를 발생시킨다. (문자 '1'과 숫자 1은 다르다)

이러한 상황에서는 일반적인 캐스팅이 아닌 문자열을 숫자로 바꿔주는 메소드를 이용해야 한다.
```C#
    string input = Console.ReadLine()
    int number = int.Parse(input);
```
int.Parse 메소드는 string 타입의 문자를 int 타입으로 변환하여 반환하는 기능을 제공한다.   
(ReadLine 메소드에서 숫자가 아닌 값을 입력하게 되면 에러가 발생한다)

## int -> string 변환

string.Format 메소드를 사용하는 방법과 스트링 인터폴레이션 문법을 사용하는 방법이 있다.

### string.Format
```C#
    int hp = 100;
    int maxHp = 200;
    string message = '당신의 HP는 ??입니다.';

    message = string.Format("당신의 HP는 {0}, MaxHP는 {1}",  hp, maxHp);
```
string.Format 메소드는 변수의 값을 지정한 자리에 치환하는 방식이다.   
이 방법의 단점은 치환해야 하는 변수가 많아질수록 과정이 번거로워진다.
   

### string interpolation(스트링 인터폴레이션)

```c#
    string message = $"당신의 HP는 {hp}입니다.";
```
문자열 앞에 $를 사용한 후 {}내부에 치환하고자 하는 변수를 넣어줌으로써 간단하게 표현이 가능하다.

