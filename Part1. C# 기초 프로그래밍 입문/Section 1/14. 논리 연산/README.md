# Section 1-14 논리 연산

## 논리 연산의 필요성
데이터를 사용할 때 변수라는 것을 사용하여 데이터를 간접적으로 사용하며  
산술 연산자를 통해 가공, 비교 연산자를 통해 특정 상황에 대한 판단을 진행한다.
이때, 어떤 사건에 대한 최종 판단의 조건이 여러개라면 논리 연산을 사용하여 판단을 할 수 있다.


## 논리 연산자 종류와 사용법
- AND 연산자(&&) : 두 값이 모두 참이여만 참(true), 그렇지 않으면 거짓(false)
- OR 연산자(||) : 두 값 중에 하나라도 참이면 참(true), 그렇지 않으면 거짓(false)
- NOT 연산자(!) : 논리 결과를 반전시킨다.

```C#
    bool isTall = true;   // 키가 크다
    bool isSmart = false; // 똑똑하다


    // 키가 크면서 똑똑하다
    // 하나라도 false면 false 결과를 반환한다.
    bool result1 = (isTall && isSmart);

    // 하나라도 true면 true 결과를 반환한다.
    bool result2 = (isTall || isSmart);

    // 결과를 반전시킨다.
    bood result3 = !isTall;
    //true -> false로 반전된다.
```