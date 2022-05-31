const usersList = [{username: "yon", password: "12312312q", Nickname: "jon", picture: "pic1.jpg", contacts: [{contact: "boo", messages: []}]},
                   {username: "boo", password: "12312312e", Nickname: "jon1", picture: "pic1.jpg"},
                   {username: "yon", password: "12312312s", Nickname: "jon2", picture: "pic1.jpg"},
                   {username: "yon", password: "12312312d", Nickname: "jon3", picture: "pic1.jpg"},];
var currentLogin = "";
var currentChat;


/*function addUser(userNameInput,passwordInput,NicknameInput,pictureInput) {
  console.log("in adduser")
  const user = {username: userNameInput, password: passwordInput, Nickname: NicknameInput, picture: pictureInput, contacts: []};
  usersList.push(user);
  console.log(usersList);
  console.log("exiting adduser")
}

/*function getUserList() {
  console.log(usersList);
  console.log("in getUserList")
  return usersList;
}*/

function registerUser(){
  const userNameInput = document.getElementById("userNameInput").value;
  let passwordInput = document.getElementById("passwordInput").value;
  const passwordInput2 = document.getElementById("passwordInput2").value;
  const NicknameInput = document.getElementById("NicknameInput").value;
  const pictureInput = document.getElementById("pictureInput").value;

  if(!valdiation(passwordInput,passwordInput2,userNameInput,NicknameInput)){
    return;
  }
  console.log("in registerUser");
  /*addUser(userNameInput,passwordInput,NicknameInput,pictureInput);*/
  usersList.push({username: userNameInput, password: passwordInput, Nickname: NicknameInput, picture: pictureInput, contacts: []});
  console.log(usersList);
  console.log("exiting registerUser")
  currentLogin = userNameInput;
  window.location = "chatScreen.html";

}


function valdiation(pass1, pass2, name, nickname){
if(name.length < 2 || nickname.length < 2){
  console.log("names input wrong");
  return false;
}
if (typeof pass1 !== "string" || typeof pass2 !== "string") {
  console.log("Passwords must be strings");
  return false; // we only process strings! 
}
if(pass1 !== pass2) {
  console.log("Passwords don't match");
  return false;
}
if (pass1.length < 8 || pass1.length > 14 || !(/^[A-Za-z0-9]*$/.test(pass1))){
  console.log("Passwords don't meet the requirements");
  return false;
}
/*return /^[A-Za-z0-9]*$/.test(pass1);*/
if (usersList.find(o => o.username == userNameInput) != undefined){
  console.log("This username is already taken");
  return false;
}
}


function loginUser(){
  const loginUsername1 = document.getElementById("loginUserInput").value;
  const loginPassword1 = document.getElementById("loginPasswordInput").value;

  console.log("in loginuser");
  console.log(usersList); 

  var item = usersList.find(o => o.username == "yon");
  if(item == undefined || item.password != loginPassword1){
    console.log("Wrong Credentials");
    return;
  }
  else{
    console.log("success");

  }
  console.log("exiting loginuser");
  currentLogin = loginUsername1;
  window.location = "chatScreen.html";
  
}

function addContact(username) {
  /*const myUser = document.getElementById("currentUser");*/

  var item = usersList.find(o => o.username == username);
  if (item != undefined) {
    if (currentLogin.contacts.find(username) == undefined) {
      currentLogin.contacts.push({ contact: username, messages: [] })
      item.contacts.push({ contact: currentLogin.username, messages: [] });
    }
    else {
      console.log(username + " is already your friend");
    }
  }
  else {
    console.log("couldn't find this contact");
  }

}

  function addMessege(messege){
    currentLogin.contacts.push(messege);
    currentChatUser.contacts.push(messege);
  }

