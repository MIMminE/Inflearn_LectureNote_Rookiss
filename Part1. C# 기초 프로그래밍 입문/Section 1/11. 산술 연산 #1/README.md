# Section 1-11 산술 연산 #1

## 사칙연산과 % 
- 일반적인 사칙연산(+ - & /)과 같은 기능을 하며 변수를 사용하든, 값을 직접 사용하든 결과는 같다.
- 수학의 사칙연산과 같이 각 연산자 별로 우선순위가 존재한다.
- 연산의 결과를 변수에 저장하거나 바로 사용하지 않으면 의미가 없는 연산이 될 수 있다.
- 연산의 결과가 소숫점이 나온다면 선언된 데이터 타입에 따라 결과가 다르게 나온다.

```C#
    int hp1 = 3 + 2 * 10; // 연산의 우선순위에 의해 23이 hp1 변수에 저장된다.
    int hp2 = hp1 - 3;    // hp1 변수의 값에서 3를 뺀 20이 hp2 변수에 저장된다.
    int hp3 = hp2 * 2;    // hp2 변수의 값에서 2를 곱한 40이 hp3 변수에 저장된다.
    int hp4 = hp3 / 2;    // hp3 변수의 값에서 2를 나눈 몫인 2가 hp3 변수에 저장된다.
```


## 몫과 나머지 연산

- 나눗셈의 몫을 구하는 연산자는 / 이다.
- 나눗셈의 나머지를 구하는 연산자는 % 이다.
```C#
    int a = 10 / 3; //10 나누기 3의 몫은 3
    int b = 10 % 3; //10 나누기 3의 나머지는 1
```


## 연산 주의점
- 나누기 연산을 할 때 0으로 나누는 동작이 발생하지 않도록 주의해야한다.
- 보통 실행이 안되지만, 아래와 같이 직접 실행되지 않으면 알 수 없는 부분도 있기에 조심히 사용해야 한다.

```C#
    int i = 0;
    int a = 10 / n; // n이 0이 아닐수도 있기에 컴파일 실행은 되자만 오류를 발생시킨다.

```

