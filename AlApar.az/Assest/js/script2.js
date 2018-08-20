
var slider = document.getElementById("myRange");
var output = document.getElementById("Max");
var output2 = document.getElementById("Min");



slider.oninput = function () {
    output.value = this.value * 5000;
}

document.querySelectorAll('a[href^="#Nav"]').forEach(anchor => {
    anchor.addEventListener('click', function (e) {
        e.preventDefault();

        document.querySelector(this.getAttribute('href')).scrollIntoView({
            behavior: 'smooth'
        });
    });
});


document.querySelectorAll("#List img").forEach(function (element) {
    element.style.height = element.offsetWidth + "px"
});

document.querySelectorAll("#VipAds img").forEach(function (element) {
    element.style.height = element.offsetWidth + "px"
});

document.querySelectorAll("#Starter img").forEach(function (element) {
    element.style.height = element.offsetWidth + "px"
});


$(document).ready(function () {

    $("#AddiitoinList").click(function () {
        $.ajax({
            url: "/Home/LoadingMoreAdsVIP?Length=" + $(".ForAjax .col-12").length,
            type: "Get",
            dataType: "html",
            success: function (response) {
                if ($(".ForAjax .col-12").length < $("#NumberOfElan").val()) {

                    $(".ForAjax").append(response);
                }
                else {

                    $(".ForAjax").append('<div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12"> <center style="padding: 5px 10px; background: red; color: white"><span >Elan bitmişdir</span></center> </div>"');
                    $("#AddiitoinList").remove()
                }


            }

        })
    })


    $("#SearchButton").click(function () {

        var MinMoney;
        if ($("#Min").val() > 0) {
            MinMoney = $("#Min").val();
        }
        else {
            MinMoney = 0;
        }

        var MaxMoney;

        if ($("#Max").val() > 0) {
            MaxMoney = $("#Max").val();
        }
        else {
            MaxMoney = 0;
        }



        $.ajax({
            url: "/Home/SearchVIP?MinMoney=" + MinMoney + "&MaxMoney=" + MaxMoney + "&Length=" + $("#NumberOfElan").val(),
            type: "Post",
            dataType: "html",
            success: function (response) {

                $(".ForAjax").html("");
                $(".ForAjax").append(response).ready(function () {

                    document.querySelectorAll("#VipList img").forEach(function (element) {
                        element.style.height = element.offsetWidth + "px"
                    });
                });
            },
            load: function () {
                $(".ForAjax").html("Gözləyin");
            }

        })





    })


})