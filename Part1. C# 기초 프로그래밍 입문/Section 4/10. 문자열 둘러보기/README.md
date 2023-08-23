# Section 4-10 문자열 둘러보기

> 문자열을 표현하는 string도 클래스이며, 내부에 여러 메소드와 static 메소드가 있다.  
> 관련 기능이 많고 꾸준히 업데이트되므로 필요한 기능이 있다면 찾아서 사용해야 한다.
---
### 찾기
```c#
string name = "Harry Potter";

// 1. 찾기
bool found = name.Contains("Harry");
int index = name.IndexOf("Ha");
```
- Contains('문자열') : 찾고자 하는 문자열의 유무 확인, bool 타입 리턴
- IndexOf('문자열') : 찾고자 하는 문자열의 인덱스 번호 확인, int 타입 리턴

---
### 변형
```C#
name = name + " Junior";
string lowerCassName = name.ToLower();
string upperCaseNmae = name.ToUpper();
string newNmae = name.Replace('r', 'l');
```
- '+' 연산자 : 문자열 추가 기능 제공, 문자열 리턴
- ToLower() : 문자열을 소문자로 변환하는 기능 제공, 문자열 리턴
- ToUpper() : 문자열을 대문자로 변환하는 기능 제공, 문자열 리턴
---
### 분할
```C#
string[] names = name.Split(new char[] { ' ' });
string substringName = name.Substring(5);
```
- Split() : 문자열을 특정 문자 기준으로 나누는 기능 제공, 문자열 배열 리턴 
- Substring() : 문자열의 특정 인덱스 이후 문자열을 추출하는 기능 제공, 문자열 리턴