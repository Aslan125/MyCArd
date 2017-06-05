app.controller("CardController", ['$rootScope', '$scope', '$mdDialog','CardService', function ($rootScope, $scope, $mdDialog,CardService) {
    console.log("I Card Controller");

    $rootScope.Cards = [];
    $rootScope.Categories = [];

    $rootScope.SelectedCard = null;
    $rootScope.OnCreateCard = function () {
        $scope.ShopDialog(null, 'create');
      

    }
    $rootScope.OnEditCard = function () {
        $scope.ShopDialog($rootScope.SelectedCard , 'edit');
    }

    $rootScope.OnRemoveCard = function () {
        var confirm = $mdDialog.confirm()
            .title("Removing Card")
            .textContent("Do you want to delete card?")
            .ok('OK')
            .cancel("Cancel");
        $mdDialog.show(confirm).then(function () {
            $scope.DeleteCard($rootScope.SelectedCard.Id);
        });
    }

    $scope.OnSelectCard = function (card) {
        console.log(card);
        $rootScope.SelectedCard=card
    }

    $scope.ShopDialog = function (card, mode) {

        $mdDialog.show({
            controller: CardDialogController,
            templateUrl: '/CardModal',
            locals: { card: card, mode: mode, Categories: $rootScope.Categories },
            parent: angular.element(document.body),
            clickOutsideToClose: true
        }).then(function (data) {
            console.log(data);
            if (mode == 'create') {
                $scope.CreateCard(data);
            } else {
                $scope.UpdateCard(data);
            }

            });
    }

    $scope.Init = function () {
        $scope.GetAllCards();
        CardService.GetCategories()
            .then(function (data) {
                console.log(data)
                $rootScope.Categories = data;
            })
            .catch(function (err) {
                console.log(err)
            });
    
    }

    $scope.GetAllCards = function () {
        $rootScope.SelectedCard = null;
        CardService.GetAllCards()
            .then(function (cards) {
                console.log(cards);
                $rootScope.Cards = cards;

            })
            .catch(function (err) {
                console.log(err);
            });
    }

    $scope.GetCard = function (id) {
        CardService.GetCard(id)
            .then(function (card) {
                console.log(card);
                $scope.SelectedCard = card;
            })
            .catch(function (err) {
                console.log(err);
            });
    }

    $scope.CreateCard = function (card) {

        CardService.CreateCard(card)
            .then(function (card) {
                console.log(card);
                $scope.GetAllCards();
            })
            .catch(function (err) {
                console.log(err);
            });
    }

    $scope.UpdateCard = function (card) {
        CardService.UpdateCard(card)
            .then(function (card) {
                console.log(card);
                $scope.GetAllCards();

            })
            .catch(function (err) {
                console.log(err);
            });
    }

    $scope.DeleteCard = function (id) {

        CardService.DeleteCard(id)
            .then(function (card) {
                console.log(card);
                
                $rootScope.Cards.splice($rootScope.Cards.indexOf($rootScope.SelectedCard), 1);
                $scope.GetAllCards();
            })
            .catch(function (err) {
                console.log("Delete err ",err);
            });
    }




}]);


function CardDialogController($scope, $mdDialog, card, mode, Categories) {
    console.log(mode, card)
    $scope.Mode = mode;
    $scope.Card = card ? angular.copy(card) : {};
    $scope.Categories = [
        { "Id": 1, "Name": "Category 1" },
        { "Id": 2, "Name": "Category 2" },
        { "Id": 3, "Name": "Category 3" },
        { "Id": 4, "Name": "Category 4" },
        { "Id": 5, "Name": "Category 5" },
    ]

    $scope.SelectedCategories=[]

    $scope.Hide = function () {
        $scope.Card.Categories = $scope.SelectedCategories;
        $mdDialog.hide($scope.Card);
    }

    $scope.Cancel = function () {
        $mdDialog.cancel();
    }

    $scope.OnChange = function () {
        console.log("Change", $scope.Card.Categories);
        console.log("Categories", $scope.Categories);
        console.log("SelectedCategories", $scope.SelectedCategories);
    }

}