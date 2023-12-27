# 목차

1. 프로젝트 설명

2. 기능 시연

3. 기술서

## 1. 프로젝트 설명

- 처음으로 만든 유니티 프로젝트입니다.
    
    간단한 조작과 풀링을 사용하여 슈팅게임을 구현하였습니다
    


## 2. 기능 시연

### 일반 몬스터 패턴
![Honeycam 2023-12-26 18-04-40](https://github.com/wlsrb0147/2DShoot/assets/50743287/4835a37d-60ea-41cb-85d1-e243e155eb88)
1. 파란색 드래곤은 총알을 쏘며, 멀면 추적하며 가까우면 회전합니다
2. 빨간 드래곤은 특정 시점의 플레이어 위치를 향해 가속하며 돌진합니다
3. 보라색 드래곤은 플레이어를 추적합니다
4. 플레이어는 2가지의 기본공격을 선택 가능하며, 필살기도 사용 가능합니다.


### 보스 드래곤 패턴
보스 드래곤에는 6가지 패턴이 존재합니다

### 1. 일반 공격 패턴

![Honeycam 2023-12-26 14-15-18](https://github.com/wlsrb0147/2DShoot/assets/50743287/62974a3d-fa2a-42b4-959c-13c6578d01ba)

### 2. 부하생성 

![Honeycam 2023-12-26 14-02-37](https://github.com/wlsrb0147/2DShoot/assets/50743287/970ff987-4406-40a8-91de-74ad784559e6)

### 3. 바둑판 패턴

![Honeycam 2023-12-26 14-15-05](https://github.com/wlsrb0147/2DShoot/assets/50743287/ad45bbf2-a7d1-4967-8336-ea6a9be8bc54)

### 4. 분신 패턴

![Honeycam 2023-12-26 14-15-09](https://github.com/wlsrb0147/2DShoot/assets/50743287/369fd840-8b9e-4a69-af02-71e4daa3c0ba)

### 5. 돌진패턴

![Honeycam 2023-12-26 14-15-14](https://github.com/wlsrb0147/2DShoot/assets/50743287/185aa2cd-03ec-4b4e-a879-7eb127466278)

### 6. 체력깎기 패턴(성공)

![Honeycam 2023-12-26 14-15-01](https://github.com/wlsrb0147/2DShoot/assets/50743287/e2ab45af-50b0-47a9-a415-50d7b9702f94)

### 체력깎기 패턴 (실패)

![Honeycam 2023-12-26 14-14-42](https://github.com/wlsrb0147/2DShoot/assets/50743287/a084a9bb-5ce4-4429-962f-20782b555306)

# 3. 개선할 수 있는 사항

- 현재는 맵을 크게 키워 움직임에 방해되지 않게하고, 맵 끝을 막아둠
    - 새로 만든 프로젝트에서는 맵 스프라이트를 9개를 사용하여, 캐릭터가 들어온 좌표에 따라 맵을 재배치 시켜 무한맵 제작할 것

- 몬스터가 파괴 이펙트를 Destroy()에서 Instantiate로 프리팹을 만들어 사용함
    - 게임이 종료되었을 때 Destory()가 실행되어 제대로 종료가 되지않음
    - 종료 애니메이션 실행으로 변경

- Pooling 실행시 스크립트 초기화가 안되는 문제가 발생
    - 초기화 로직을 Reset()에 적용시켜,  Reset() 실행시킴

- Pooling으로 만든 Prefab이 하이어라키에 늘어져 게임오브젝트 식별 불가
    - 비활성화된 게임오브젝트는 GameManager의 자식으로 만들어 정리함

### Find 문제 - 성능 이슈

현재 몬스터 숫자, 몬스터의 플레이어 정보는 Find를 사용하여 가져오기에 성능문제가 발생함

- 개선 방법
    - Player을 Singleton에 등록 후, 플레이어 정보를 Singleton에서 참조할 것
    - 몬스터가 생성될 때, Singleton의 리스트에 자신을 등록하고, 파괴될 때 리스트에서 제거하여 몬스터 숫자를 인식할 것

