function sleep(delay) {
    var start = new Date().getTime();
    while (new Date().getTime() < start + delay);
}

$(window).on('load', function () {
    $('#loader').hide();
    $('#myUL').css('display', 'block')
})

function myFunction() {
    var input, filter, ul, li, h3, i, p, txtValue;
    input = document.getElementById("myInput");
    filter = input.value.toUpperCase();
    ul = document.getElementById("myUL");
    li = ul.getElementsByTagName("li");


    for (i = 0; i < li.length; i++) {
        h3 = li[i].getElementsByTagName("h3")[0];
        p = li[i].getElementsByTagName("p")[0];
        // Select the whole paragraph
        var ob = new Mark(p);

        // First unmark the highlighted word or letter
        ob.unmark();
        pValue = p.textContent || p.innerText || p.innerHTML;
        txtValue = h3.textContent || h3.innerText || h3.innerHTML;
        if (txtValue.toUpperCase().indexOf(filter) > -1 || pValue.toUpperCase().indexOf(filter) > -1) {
            li[i].style.display = "";


            // Highlight letter or word
            ob.mark(
                document.getElementById("myInput").value, {
                className: 'a'
            }
            );

        } else {
            li[i].style.display = "none";
        }

    }
}