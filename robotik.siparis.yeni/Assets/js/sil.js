
function showAchievement() {
    var table = '';
    var tableTag = '<table id="mytable" class="table" style="margin-top:10px;">';
    var tableHead = '<thead><tr><th>#</th><th>Ders</th><th>Not</th><th>Tarih</th><th>';
    var tableFooter = '</tbody></table>';
    var rows = '';
    var id = $('#classList').val();
    $.get('/Home/GetLessonList/' + id, function (data) {
        //document.getElementById("info").innerHTML = '<div><div class="col-md-4">' + data['classroom'] + '</div><div class="col-md-4">' + data['education'] + '</div><div class="col-md-4"><button class="btn btn-success" onclick="OpenAchievement(' + data['classId'] + ')">Kazanım Ekle</button></div></div>';
        tableHead += '<button class="btn btn-label-twitter" onclick="OpenAchievement(' + data['classId'] + ')">Kazanım Ekle</button></th ></tr ></thead ><tbody>'

        var i = data['achievements'].length;
        for (let prop of data['achievements']) {
            var dateStr = new Date(parseInt(prop['date'].substr(6)));
            var mounth = dateStr.getMonth() + 1;
            dateStr = dateStr.getDate() + '.' + mounth + '.' + dateStr.getFullYear();
            rows += '<tr><td>' + i + '</td><td>' + prop['lesson'] + '</td><td>' + prop['note'] + '</td><td>' + dateStr + '</td><td width="250"><button class="btn  btn-label-facebook" onclick="OpenInspection(' + prop['id'] + ')">Yoklama Al</button> <button class="btn btn-label-danger" onclick="EditAchievement(' + prop['id'] + ')">Düzenle</button>  <button onclick="DeleteAchievement(' + prop['id'] + ')" class="btn btn-label-youtube" value="' + prop['id'] + '">Sil</button></td></tr>';
            i--;
        }
        table = tableTag + tableHead + rows + tableFooter;
        document.getElementById("fillTable").innerHTML = table;
        var j = 1;
        var lessList = '';
        for (let prop of data['lessons']) {
            lessList += '<option value="' + prop['id'] + '">' + j + '. ' + prop['name'] + '</option>';
            j++;
        }
        $("#lessonList").find('option').remove();
        $('#lessonList').append('<option disabled selected value="">Lütfen ders seçiniz.</option>' + lessList);
    });
}