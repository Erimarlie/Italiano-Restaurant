import axios from 'axios';

const DrinkStore = {
    state: {
        drink: []
    },

    // Drink methods

    getDrink() {
        return this.state.drink;
    },

    getDrinkById(id) {
        return this.state.drink.find(drink => drink.drinkId == id);
    },

    setDrink(drink) {
        this.state.drink = drink;
    },

    setDrinkRating(vote, id) {

        // Constructing the object to post
        let updateRating = {rating: vote, drinkFK: id};

        axios.post("https://localhost:5001/drinkratings", updateRating);
    },

    editDrink(item) {

        // Constructing the object from item
        // due to item containing a few more variables than it should
        const edit = {
            drinkId: item.drinkId, 
            name: item.name,
            category: item.category,
            description: item.description,
            price: item.price,
            imgSrc: item.imgSrc 
        }

        // Put to backend
        axios.put("https://localhost:5001/drinkmenu", edit);
    },

    addDrink(item) {

        // Construct object
        const add = {
            name: item.name,
            category: item.category,
            description: item.description,
            price: item.price,
            imgSrc: item.imgSrc
        }

        // Post to backend
        axios.post("https://localhost:5001/drinkmenu", add).then( response => {
            // Push to array
            this.state.drink.push(response.data);
        })
    },
    deleteDrink(id) {

        // Delete drink
        axios.delete(`https://localhost:5001/drinkmenu/${id}`);

        // Delete ratings associated with drink
        axios.delete(`https://localhost:5001/drinkratings/${id}`);
    }
}

export default DrinkStore;
    