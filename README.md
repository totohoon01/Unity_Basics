<h2>2021-04-05 ~ </h2>

<h3>Terms</h3>

> <ul>
>    <li>Mesh : 3D 모델</li>
>    <li>Material : 메쉬에 적용할 텍스쳐의 속성 정보</li>
>    <li>Texture : 모델의 표면에 그려지는 이미지 파일</li>
>    <b>Texture -> Material -> Mesh</b>
>    <li>Triangle : Mesh를 구성하는 면 요소(삼각형)</li>
>    <li>Vertex : Triangle의 각 꼭짓점</li>
> </ul>
> <h4>Scene, Game Object</h4>
> <ul>
> <li>Scene : 월드맵, 엔딩 등</li>
> <li> Game Object : Scene을 구성하는 모든 객체</li>
> </ul>
> <h4>Prefab</h4>
> - 객체지향 같은 개념. 클래스를 만든 후, 인스턴스로 복제해 사용한다.
>
> <h4>Component Based Developement</h4>
> - 오브젝트에 필요한 <b><i>'컴포넌트'</i></b>를 추가, 제거하는 방식으로 개발

<h3>Short Cuts</h3>

> <ul>
> <li><b>Q,W,E,R,T, Y : Tools</b><br></li>
> <li><b>Ctrl + Shift + C : Console view</b><br></li>
> <li><b>Ctrl + D : Duplicate</b><br></li>
> <li><b>Ctrl + P : Play / Stop</b><br></li>
> <li><b>Ctrl + Shift + P : Pause</b><br></li>
> <li><b>Ctrl + Alt / Alt : View 조정 가능</b><br></li>
> <li><b>Shift + F : 특정 오브젝트 포커싱</b></li>
> </ul>

<h3>Essential Tips</h3>
 
 > <b> Pivot, Local, Hierarchy-Sorting</b><br>
 > <b> 1 grid = 1 unit (X,Y,Z축 1단위)</b><br>
 > <b>Capsule모델 : 일반적인 사람 사이즈</b>
![capsulemodel.png](./img/capsulemodel.PNG)

<h3>Materials</h3>

> Materials폴더 : 예약명(Materials), 폴더를 만들고 Material 객체에 텍스쳐 할당<br>
> Albedo - 텍스쳐 정보, Normal Map - 간단한 쉐이딩<br>
> Material 오브젝트 안에 옵션이 있음.

<h3>Input</h3>

> 입력장치의 이벤트를 받아옴, Input Manager에서 설정가능.
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

<h3>Animation Type</h3>

> <ul>
>     <li> <b>Legacy</b> (가벼운 모델, 코드로 지정함)</li>
>     <li> <b>Mecanim</b>
>         <ul>
>         <li> <b>Hummanoid</b> : 사람</li>
>         <li> <b>Generic</b> : 동물 등등</li>
>         (동적 애니메이션 구성 가능)
>         </ul>
>     </li>
>     <br>
>     <li> <b>Animation</b> Componet : Legacy</li>
>     <li> <b>Animator</b> Componet : Mecanim</li>
> </ul>

<h3>Animation 설정</h3>
<i>code</i>

```
private float lb;
public Animation anim;
anim = GetComponent<Animation>();
lb = Input.GetAxis("Fire1"); //Project Setting -> Input Manager(이름 및 입력받을 키 지정)
if(lb >0){
    anim.CrossFade("IdleFireSMG"); //IdleFireSMG라는 애니메이션 동작, CrossFade -> 자연스러운 전환
}
```

<h3>Physics</h3>

> <ul>
> <li>Mass : 무게</li>
> <li>Drag : 마찰력</li>
> <li>is Kinematic : 스크립트를 이용해 움직임을 적용(물리엔진 작용x)</li>
> <li>interpolate : 물리엔진의 계산값, 렌더링 프레임의 차이에 따른 jiterring 발생, 보정해주는 옵션</li>
> <li>Collision : 속도가 너무 빠른 물체 - Discrete로 감지 못할수도 있음. 밑에 옵션은 잘 감지하는 대신 부하가 커짐.</li>

> </ul>
> <h4>Collision</h4>
> sphere - capsule - box 순으로 빠름
