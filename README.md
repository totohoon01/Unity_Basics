<h2>2021-04-05 ~ </h2>

<h3>Terms</h3>

> <ol>
>    <li>Mesh : 3D 모델</li>
>    <li>Material : 메쉬에 적용할 텍스쳐의 속성 정보</li>
>    <li>Texture : 모델의 표면에 그려지는 이미지 파일</li>
>    <b>Texture -> Material -> Mesh</b>
>    <li>Triangle : Mesh를 구성하는 면 요소(삼각형)</li>
>    <li>Vertex : Triangle의 각 꼭짓점</li>
> </ol>
> <h4>Scene, Game Object</h4>
> Scene : 월드맵, 엔딩 등<br>
> Game Object : Scene을 구성하는 모든 객체
>
> <h4>Prefab</h4>
> 객체지향 같은 개념. 클래스를 만든 후, 인스턴스로 복제해 사용한다.
>
> <h4>Component Based Developement</h4>
> 오브젝트에 필요한 <b><i>'컴포넌트'</i></b>를 추가, 제거하는 방식으로 개발

<h3>Short Cuts</h3>
 
 > <b>Q,W,E,R,T : Tools</b><br>
 > <b>Ctrl + Shift + C : Console view</b><br>
 > <b>Ctrl + D : Duplicate</b><br>
 > <b>Ctrl + P : Play / Stop</b><br>
 > <b>Ctrl + Shift + P : Pause</b><br>
 > <b>Ctrl + Alt / Alt : View 조정 가능

<h3>Essential Tips</h3>
 
 > <b> Pivot, Local, Hierarchy-Sorting</b><br>
 > <b> 1 grid = 1 unit (X,Y,Z축 1단위)</b><br>
 > <b>Capsule모델 : 일반적인 사람 사이즈</b>
![capsulemodel.png](./img/capsulemodel.PNG)

<h3>Material</h3>

> Materials폴더 : 예약명(Materials), 폴더를 만들고 Material 객체에 텍스쳐 할당
> Albedo - 텍스쳐 정보, Normal Map - 간단한 쉐이딩

<h3>Input</h3>

> 입력장치의 인풋, Input Manager에서 설정가능.
> 스크립트에서 Input 클래스로 받아올 수 있다.

<i>code</i>

```
float h = Input.GetAxis("Horizontal); // 이름이 정해져있음.
float v = Input.GetAxis("Vertical);

Vector3 moveDir = Vector3.forward * v + Vector3.right *  h; //앞뒤, 좌우
transform.Translate(moveDir.nomalized * 0.1f, Space.Self); // Space.Self : 객체를 기준으로 이동(기본 값)

//Vector3.forward == new Vector3(0,0,1)
//Vector3.up      == new Vector3(0,1,0)
//Vector3.right   == new Vector3(1,0,0)
//Vector3.one  == new Vector3(1,1,1)
//Vector3.zero == new Vector3(0,0,0)
```
