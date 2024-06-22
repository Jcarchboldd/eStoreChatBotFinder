$(document).ready(function () {
    $(document).on('click', '.page-link', function (e) {
        console.log('Pagination button clicked'); // Debugging line
        var loadPageUrl = $('[data-load-page-url]').data('load-page-url');
        console.log(loadPageUrl); // Debugging line
        e.preventDefault();
        var pageNumber = $(this).data('page');
        $.ajax({
            url: loadPageUrl, // Use the variable from the Razor view
            type: 'GET',
            data: { productPage: pageNumber },
            success: function (result) {
                $('#productListContainer').html(result);
            }
        });
    });
});

