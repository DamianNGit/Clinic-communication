var numer = Math.floor(Math.random() * 5) + 1;

        function hide() {
            $("#slider").fadeOut(500);
        }

        function slider() {
            numer++;
            if (numer > 5) numer = 1;

            var plik = "<img class=\"img-responsive\" alt=\"Slider\" src=\"img/slides/slide" + numer + ".jpg\">";

            document.getElementById("slider").innerHTML = plik;
            $("#slider").fadeIn(500);
            
            setTimeout("slider()", 5000);
            setTimeout("hide()", 4500);
        }