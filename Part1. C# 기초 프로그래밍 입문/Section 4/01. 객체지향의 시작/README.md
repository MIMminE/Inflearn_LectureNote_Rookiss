# Section 4-1 객체지향의 시작

## 절차지향 방식의 특징

> * 어떤 기능을 함수로 구현하여 함수끼리 연결시켜 전체 프로그램 동작을 구현하는 방식이다.
>* 간단하고 직관적인 장점이 있어 간단하거나 소규모의 프로젝트에서는 유용하다.
>* 규모가 커지면 유지보수가 어려워진다. 
>* 함수끼리의 연결이 강하게 되어 있는 경우가 많아 수정이 어렵다. (순서에 종속적이다.)


## 객체지향
> * OOP (Object Oriented Programming)
> * 눈에 보이는 모든 사물과 보이지 않는 개념 모두를 객체라 부른다.
> * 객체는 각자 속성과 기능을 가지고 있다.
> * Knight 객체 기준으로 hp, attack, pos(위치) 등의 속성을 가질 수 있다.
> * Knight 객체 기준으로 Move, Attack, Die 등의 기능을 가질 수 있다.
> * class 명령어를 통해 클래스를 선언하여 객체를 만들 틀을 만들 수 있다.

```c#   
    class Knight 
    {
        public int hp;
        public int attack;

        public void Move()
        {
            Console.WriteLine("이동합니다.");
        }

        public void Attack()
        {
            Console.WriteLine("공격합니다.");
        }

    }
```
   
> * 속성과 메소드 앞에 public를 붙이는 이유는 생성된 객체에 외부에서의 접근을 허용하기 위함이다.

```c#
	Knight knight = new Knight();
```
> * 객체를 생성하기 위해서는 new 연산자를 사용한다.
> * new 연산자를 사용하지 않으면 오류가 발생한다.
> * 만약 null 객체를 할당할 경우 실행은 가능하나 오류가 발생한다. (많은 오류 유발 사항)

### 클래스는 설계도를 만드는 것과 같으며, 설계도를 통해 실제 객체를 생성(new)해줘야 한다.
