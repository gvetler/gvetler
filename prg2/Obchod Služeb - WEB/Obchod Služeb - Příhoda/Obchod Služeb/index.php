<?php session_start(); ?>
<html>
    <head>
		<meta charset="utf-8">
        <title>Nabídka služeb</title>
		<link rel="stylesheet" href="styly/default.css">
    </head>
    <body>
        <!-- Služby -->
		<div id="sluzby">
			<div class="sluzba">
				<h1>Hlídání dětí</h1>
				<h2>Popis Služby:</h2>
				<p>Hlídání dětí všech věkových kategorií. Jsme tradiční rodinná firma a zakládáme si na osobním přístupu - vyhovíme všem Vašim přáním.</p>
				<img src=".\Služby obrázky\Hlídání dětí.jpg" alt="Hlídání dětí" />
			</div>
			<div class="sluzba">
				<h1>Ostraha</h1>
				<h2>Popis Služby:</h2>
				<p>Jsme nejlepší a nejvíc vybavená společnost Kotlár S.R.O, když budete potřebovat ochranu víte na koho se obrátit</p>
				<img src=".\Služby obrázky\Ostraha.jpg" alt="Ostraha" />
			</div>
			<div class="sluzba">
				<h1>Pečovatelská služba</h1>
				<h2>Popis Služby:</h2>
				<p>
					Služby, které naše organizace zajišťuje, jsou poskytovány formou pobytovou, ambulantní i terénní. Nabízíme tak zejména seniorům a jejich rodinám pomoc při vytváření důstojných podmínek pro život v jejich přirozeném prostředí a
					pomáháme jim překonávat osamění.
				</p>
				<img src=".\Služby obrázky\Pečovatelská služba.jpg" alt="Pečovatelská služba" />
			</div>
			<div class="sluzba">
				<h1>Půjčovna aut</h1>
				<h2>Popis Služby:</h2>
				<p>
					Po domluvě Vám automobil dovezeme k Vám domů, do firmy, či na jiné místo dle Vašeho přání. Všechny naše vozy jsou v perfektním technickém stavu, mají povinné a havarijní pojištění a zaručují ten nejlepší možný komfort za
					přijatelnou cenu. Půjčovna kabrioletů - půjčte si u nás kabriolet a vyzkoušejte si jaké to je řídit se staženou střechou. Naše vozy nejsou polepeny žádnou reklamou.
				</p>
				<img src=".\Služby obrázky\Půjčovna aut.jpg" alt="Půjčovna aut" />
			</div>
			<div class="sluzba">
				<h1>Rozvoz jídel</h1>
				<h2>Popis Služby:</h2>
				<p>Hlavní činností naší firmy je výroba a rozvoz čerstvých chlazených jídel výhradně do firem a institucí. Dále nabízíme výrobu jídel pro restaurace a pro mimořádné akce.</p>
				<img src=".\Služby obrázky\Rozvoz jídel.jpg" alt="Rozvoz jídel" />
			</div>
			<div class="sluzba">
				<h1>Ubytovací služba</h1>
				<h2>Popis Služby:</h2>
				<p>
					Poskytování ubytování ve všech ubytovacích zařízeních (například hotel, motel, kemp, ubytovna) a v bytových domech, rodinných domech nebo ve stavbách pro rodinnou rekreaci. V případě ubytování v bytových domech, rodinných domech
					nebo ve stavbách pro rodinnou rekreaci s kapacitou do 10 lůžek (včetně přistýlek) podávání snídaní ubytovaným hostům.
				</p>
				<img src=".\Služby obrázky\Ubytovací služba.jpg" alt="Ubytovací služba" />
			</div>
			<div class="sluzba">
				<h1>Úklidová služba</h1>
				<h2>Popis Služby:</h2>
				<p>
					Poskytujeme kompletní úklidové služby, pravidelný i jednorázový úklid, přesně podle Vašich požadavků. Nabízíme své služby v oblasti poskytování kvalitních úklidových služeb včetně všech podpůrných procesů a kompletní hygienický
					servis. Provádíme veškeré vnitřní a venkovní úklidové práce pravidelně i jednorázově, včetně kanceláří, hotelů, společenských prostor. Uklízíme veškeré plochy, přesně dle požadavků vás našich zákazníků. Zakázky vyřizujeme do 24
					hodin. Uklízíme v lokalitě Most a okolí včetně zbytku ústeckého kraje.
				</p>
				<img src=".\Služby obrázky\Úklidová služba.jpg" alt="Úklidová služba" />
			</div>
		</div>
		<div id="formulare">
			<div id="majitel">
				<h1>Vypsání rezervací pro majitele</h1>
				<form method="post" action="prihlaseni.php">
					<div>
						<span>Jméno:</span>
						<input type="text" name="jmeno" />
					</div>
					<div>
						<span>Heslo:</span>
						<input type="password" name="heslo" />
					</div>
					<input type="submit" value="Vypsat rezervace" />
				</form>
			</div>
			<hr />
			<div id="objednavani">
				<h1>Objednávka</h1>
				<form method="post" action="action.php">
					<div>
						<span>Jméno:</span>
						<input type="text" name="jmeno" />
					</div>
					<div>
						<span>E-mail:</span>
						<input type="text" name="email" />
					</div>
					<div>
						<span>Datum rezervace:</span>
						<input type="date" name="datum" />
					</div>
					<div>
						<span>Služba:</span>
						<select name="sluzby">
							<option value="Půjčovna">Půjčovna</option>
							<option value="Úklidová služba">Úklidová služba</option>
							<option value="Rozvoz jídel">Rozvoz jídel</option>
							<option value="Hlídání dětí">Hlídání dětí</option>
							<option value="Pečovatelská služba">Pečovatelská služba</option>
							<option value="Ostraha">Ostraha</option>
							<option value="Ubytovací služba">Ubytovací služba</option>
						</select>
					</div>
					<input type="submit" value="Odeslat" />
				</form>
			</div>
			<?php if($_SESSION['chyba']) echo "<hr />";?>
			<div>
				<h2 id="chyba">
					<?php
						if ($_SESSION['chyba'])
						{
							echo "{$_SESSION['chyba']}";
							$_SESSION['chyba'] = null;
						}
					?>
				</h2>
			</div>
		</div>
    </body>
    
    <!-- odstraní reklamu --> 
    <script>
        document.getElementsByTagName("div")[document.getElementsByTagName("div").length-2].hidden = true;
    </script>
</html>
