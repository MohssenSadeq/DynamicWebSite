  var  bbb = 0;
                     $(function () {
                         var btn = document.getElementById("more");
                         
                         $("#more").click(function () {

                             if (bbb == 0) {
                                 btn.innerHTML = "عرض أقل <span class=\"glyphicon glyphicon-arrow-up\"></span>";
                                 bbb=1;
                             }
                             else {
                                 btn.innerHTML = "عرض أكثر <span class=\"glyphicon glyphicon-arrow-down\"></span>";
                                bbb=0;
                             }
                         })
                     })