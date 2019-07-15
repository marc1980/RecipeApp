// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function(){
    $(".deleteRecipeModal").on("click",  function(){
        var deleteRecipeId = $(this).data('recipe-id');
        $("#recipeId").val( deleteRecipeId );
    });

    $("#btnAddReview").on("click", function () {
        $.ajax({
            url: '/Recipes/AddReview',
            type: 'post',
            data: $('form#addReview').serialize(),
            success: function (data) {
                $('#inputReviewer').val("");
                $('#inputBody').val("");
                $('#reviewsWrapper').replaceWith(data);
            }

        });
    });
 });
