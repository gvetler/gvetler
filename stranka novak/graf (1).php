<!DOCTYPE html>
<html>
  <head>
      <center>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">
      google.charts.load('current', {'packages':['bar']});
      google.charts.setOnLoadCallback(drawChart);

      <?php
        $x1=[100,100,85,150,400];
        $x2=[330,120,95,200,500];
      ?>

      function drawChart() {
        var data = google.visualization.arrayToDataTable([
          ['Týden', 'Počet ujetých km za 1. měsíc', 'Průměr', 'Počet ujetých km za 2. měsíc'],
          <?php
          for ($i = 0; $i < 5; $i++) {
              echo '["'.$i+1 . '", ' . $x1[$i] . ", " . ($x1[$i]+$x2[$i])/2 . ", " . $x2[$i] . "],";
            
          }
          ?>
        //   ['1', 1, 400, 200],
        //   ['2', 11, 460, 250],
        //   ['3', 9, 1120, 300],
        //   ['4', 8, 540, 350]
        //   ['5', 7, 400, 200],
        ]);

        var options = {
          chart: {
            title: 'Počet ujetých km za 2 měsíce',
            subtitle: '1. - 4. týden',
          }
        };

        var chart = new google.charts.Bar(document.getElementById('columnchart_material'));

        chart.draw(data, google.charts.Bar.convertOptions(options));
      }
    </script>
  </head>
  <body>
    <div id="columnchart_material" style="width: 800px; height: 500px;"></div>
  </body>
</html>