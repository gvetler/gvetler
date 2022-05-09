<form action="obsluhaprihlaseni.php" method="post">
  <div class="container">
    <label for="uname"><b>Username</b></label>
    <input type="text" placeholder="Enter Username" name="username" required>

    <label for="psw"><b>Password</b></label>
    <input type="password" placeholder="Enter Password" name="password" required>
    <input type="submit" value="Přihlásit" />
    <label>
      <input type="checkbox" checked="checked" name="remember"> Remember me
    </label>
  </div>

  <div class="container" style="background-color:#f1f1f1">
</div>
</form>
<?php
if($_POST['username'] == 'admin' && $_POST['password'] == 'admin') {
    header("Location: http://mojepujcovna.borec.cz/obsluha.php");
}else{
    echo '<script>alert("Špatné údaje")</script>';
}
?>