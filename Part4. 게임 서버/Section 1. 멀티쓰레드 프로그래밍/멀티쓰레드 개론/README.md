# Section 4 : 멀티쓰레드 개론

식당을 운영하는 것과 굉장히 비슷한 느낌을 가지고 있다.

등장 요소
- 고급 레스토랑 (프로세스, 프로그램)
- 로봇 직원 (쓰레드)
- 영혼 (CPU 코어)
  

여러 식당이 있고 각 식당에 로봇직원이 있다.
(기본적으로 하나의 쓰레드가 할당된다. 이런것을 싱글쓰레드 방식이라고 한다)

쓰레드를 실행시키는 주체는 CPU코어이다.
코어 한개당 한번에 실행시킬 수 있는 프로세스는 하나이다.

굉장히 빠른 시간동안 여러 프로레스를 왔다갔다하면서 동작한다.
(사용자 눈에는 동시에 사용되는 것처럼 실행된다.)


