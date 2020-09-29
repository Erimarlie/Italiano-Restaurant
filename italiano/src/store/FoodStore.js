import axios from 'axios';

const FoodStore = {
    state: {
        food: []
    },

    // Food methods
    getFood() {
        return this.state.food;
    },
    getFoodById(id) {
        return this.state.food.find(food => food.foodId == id);
    },
    setFood(food) {
        this.state.food = food;
    },
    setFoodRating(vote, id) {

        // Sets the object to put
        let updateRating = {rating: vote, foodFK: id};

        // Sends the object to back-end
        axios.post("https://localhost:5001/foodratings", updateRating);
    },
    editFood(item) {

        // Constructing the object from item
        // due to item containing a few more variables than it should
        const edit = {
            foodId: item.foodId, 
            name: item.name,
            category: item.category,
            description: item.description,
            price: item.price,
            imgSrc: item.imgSrc 
        }

        // Put to backend
        axios.put("https://localhost:5001/foodmenu", edit);
    },
    addFood(item) {

        // Construct object
        const add = {
            name: item.name,
            category: item.category,
            description: item.description,
            price: item.price,
            imgSrc: item.imgSrc
        }

        // Post to backend
        axios.post("https://localhost:5001/foodmenu", add).then( response => {
            // Push to array
            this.state.food.push(response.data);
        })
    },
    deleteFood(id) {

        // Delete food
        axios.delete(`https://localhost:5001/foodmenu/${id}`);

        // Delete ratings associated with food
        axios.delete(`https://localhost:5001/foodratings/${id}`);
    }
}

export default FoodStore;