#pragma strict

var plane : GameObject;

var character : GameObject;

var offset : float;

var directionFaced : Direction1;




function Update () {
if (directionFaced == Direction1.X){
offset = (plane.transform.position.x - character.transform.position.x);
transform.position.x= plane.transform.position.x + offset;
transform.position.y= character.transform.position.y;
transform.position.z= character.transform.position.z;
}
if (directionFaced == Direction1.Y){
offset = (plane.transform.position.y - character.transform.position.y);
transform.position.x= character.transform.position.x;
transform.position.y= plane.transform.position.y + offset;
transform.position.z= character.transform.position.z;
}
if (directionFaced == Direction1.Z){
offset = (plane.transform.position.z - character.transform.position.z);
transform.position.x= character.transform.position.x;
transform.position.y= character.transform.position.y;
transform.position.z= plane.transform.position.z + offset;
}
}
public enum Direction1{
X,Y,Z
}