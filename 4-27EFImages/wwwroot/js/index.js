$(() => {

    
    function RefreshTable() {

        $('tbody').empty();

        $.get('/home/GetImages', obj => { //GetImages returns the "ImageJsonModel" which contains 2 properties: images, likedImageIds. Obj represents the values of both. 
          obj.images.forEach(img => {
               // $('tbody').append(
                var html =
                    `<tr>
                       <td>
                          <a href="${img.imageUrl}" target="_blank">
                            <h6>${img.title}</h6>
                           <img src="${img.imageUrl}" height=50 width=50 />
                         </a>
                      </td>
                       <td><h6>${img.uploadDate}</h6></td>
                       <td>${img.countLikes}</td>
                       <td><button `

                //if the current imageId was already liked i.e. in the list of imageids stored in the cookie. 
                if (obj.likedImageIds !== null) {
                    if (obj.likedImageIds.includes(img.id)) {
                               html += 'disabled ';
                           }
                }
                            
                      html += `data-imageid="${img.id}"  class="btn btn-success like">Like!
                             <img height = "30" width = "30" src = "data:image/jpeg;base64,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" />
                         </button> 
                        </td >
                       </tr >`;

               $('tbody').append(html);
             });
        });
    }



    RefreshTable();

    $("#add-image").on('click', function () {

        const url = $("#img-url").val();
        const title = $("#img-title").val();

        const img = {
            imageUrl: url,
            title: title,
            //uploadDate: new Date(),
            countLikes: 0
        }

        $.post('/home/AddImage', img, function () {
            RefreshTable();
            $("#img-url").val('');
            $("#img-title").val('');
        });

    });

     $('tbody').on('click','.like', function () {
                                                      
        const id = $(this).data('imageid');
        const countLikes = parseInt($(this).data('countlikes'));

        const img = {
            id
        }
         
         $.post('/home/UpdateLikes', img, function () {

             //not ncessary because they won't have a chance to click once it's liked as it will be disabled 
             //if (obj.alreadyliked) {
             //    alert('You can only "like" an image once! Count will not be increased');
             //}
         });

         $(this).prop('disabled', true); //once this image was liked, disable it so it can't be liked again by this user.note: this is necessary only until the refresh happens again as when it recreates the records, it will disable the like based on the latest list of liked.  
    });

   //// refresh every 5 seconds
    setInterval(() => {
        console.log(new Date()),
        RefreshTable() }, 5000  );


});