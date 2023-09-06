# Section 2-1 if와 else

분기문 : 여러 갈래에서 하나를 선택하게 하는 문법.

```C#
    int hp = 100;
    bool isDead = (hp <= 0);

    if (isDead){
        Console.WriteLine("You are dead");
    }
```


if 문 괄호안의 결과가 참이면 실행되는 코드를 작성한다.

```C#
    if (isDead)
        Console.WriteLine("You are dead");
```
- 탭 키를 이용하여 띄어쓰기로 맞춰주는 이유는 가독성의 측면이 있다. 
- 조건안에서 실행되어야 할 코드가 딱 한줄이면 중괄호를 생략할 수 있다.
- 파이썬 같은 언어는 탭 키를 이용한 여백 관리가 코드에 영향을 끼치지만 C#은 아니다.


```C#
    if (isDead)
        Console.WriteLine("You are dead");
    else
        Console.WriteLine("You are alive");
```


```C#
    int choice = 0;

    if (choice == 0)
        Console.WriteLine("가위입니다");
    if (choice == 1)
        Console.WriteLine("바위입니다");
    if (choice == 2)
        Console.WriteLine("보입니다");
```


```C#
    int choice = 0;

    if (choice == 0)
        Console.WriteLine("가위입니다");
    else{
        if (choice == 1)
            Console.WriteLine("바위입니다");
        else
            Console.WriteLine("보입니다");
    }
```