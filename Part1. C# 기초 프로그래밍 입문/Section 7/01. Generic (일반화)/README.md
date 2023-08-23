# Section 7-1 Generic (일반화)
***Date : 2023. 08. 23***
> Generic(일반화)는 데이터 타입을 일반화하고 재사용 가능한 코드를 작성하기 위한 문법이다.

### object 클래스
- 객체 생성을 위한 클래스의 최상위 부모 클래스이다.
- System.Object 클래스를 가리킨다.
- 모든 클래스는 Object 클래스의 상속을 직간접적으로 받는다.
- Equals, GetType 등의 메소드를 가지고 있다.
- 모든 클래스의 부모 클래스이므로 모든 클래스로 캐스팅될 가능성을 가지고 있다. (업캐스팅의 개념)

```C#
  object objString = "Hello";  // 문자열을 object로 저장
  object objInteger = 3;      // 정수를 object로 저장

  string str = (string)objString; // object를 문자열로 캐스팅
  int num = (int)objInteger;      // object를 정수로 캐스팅
```

### var 타입 
- 변수를 선언할 때 사용되는 키워드로, 변수의 데이터 타입을 컴파일러가 자동으로 추론하게 한다.
- object와는 달리 컴파일러가 데이터 타입을 추론하여 실제 할당하게 되므로 캐스팅에 있어서 각 추론 데이터 타입의 성격에 따른다.
- 디버그를 통해 var이 어떤 데이터 타입으로 추론되었는지 확인이 가능하다.
```C#
  var varString = "Hello";  // string 으로 추론
  var varInteger = 3;       // int로 추론
```

### 10개 공간을 가지는 배열 클래스
- 각 타입에 해당하는 10개 공간의 배열을 클래스를 생성하는 클래스는 아래와 같이 나타낼 수 있다.
- 클래스 하나만으로 모든 클래스에서 사용할 수 있는 배열을 만들기 위해 object 클래스를 사용한다.
- 사용은 가능하나 사용하기 위해 매번 object 클래스에 대한 캐스팅을 명시해야하며, 캐스팅 과정에서의 컴파일 에러 가능성이 존재한다.
```C#
  class Monster { }

  class MonsterArr
  {
      Monster[] arr = new Monster[10]; 
  }

  class IntArr
  {
      int[] arr = new int[10]; 
  }
    
  class FloatArr
  {
      float[] arr = new float[10];    
  }

    class ObjectArr
  {
      object[] arr = new object[10];
  }
```

### Generic의 사용법
- <>를 이용하여 지정하는 타입 매개변수를 이용하여 클래스를 선언할 때 데이터 타입을 명시한다.
- 클래스 내부에서 실제 데이터 타입을 대체한다.
```C#
  class MyList<T>
  {
      T[] arr = new T[10];    
      
      public T getItem(int i)
      {
        return arr[i];
      }
  }

  class Program
  {
      static void Main(string[] args)
      {
          MyList<Monster> list = new MyList<Monster>();
          list.arr[0] = new Monster("Skeleton");
          string monsterName = list.getItem(0).monsterName;
      }
  }
```

### 함수의 Generic
- 메소드를 정의할 때도 Generic 문법을 사용할 수 있다.
```C#
  static void FindFirst<T>(T[] list)
  {
      Console.WriteLine(list[0]);
  }

  static void Main(string[] args)
  {
      FindFirst<int>(arr);
  }

```

### Generic의 유용한 기법
```C#
  static void TestFuc<T, M>(){ // 타입 매개변수를 여러개 지정할 수도 있다.
    T member;
    M team;
  } 

  class Mylist<T> where T : strcut {} // T에 대한 조건 : 값 형식 
  class Mylist<T> where T : class {}  // T에 대한 조건 : 참조 형식(클래스)
  class Mylist<T> where T : new() {}  // T에 대한 조건 : 기본 생성자만
  class Mylist<T> where T : Monster {} // T에 대한 조건 : Monster 클래스
```
