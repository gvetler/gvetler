<!DOCTYPE html>
<html>
<head>
    <title>Odeslání emailu</title>
</head>
<body>

	<center>
		<h4 class="sent-notification"></h4>

		<form method="post" action="sendEmail.php">
			<h2>Send an Email</h2>

			<label>Jméno</label>
			<input name="jmeno" type="text" placeholder="Zadejte Jméno">
			<br><br>

			<label>Email</label>
			<input name="email" type="text" placeholder="Zadejte Email">
			<br><br>

			<label>Předmět</label>
			<input name="predmet" type="text" placeholder="Zadejte Předmět">
			<br><br>

			<p>Zpráva</p>
			<textarea name="zprava" rows="5" placeholder="Napište zprávu"></textarea>
			<br><br>

			<button type="submit" name="submit" value="Odeslat Email">Odeslat</button>
		</form>
	</center>
</body>
</html>
