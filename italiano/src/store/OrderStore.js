const OrderStore = {
    state: {
        order: [],
        customerInfo: [],
        total: 0
    },
    getOrder() {
        return this.state.order;
    },
    getTotal() {
        return this.state.total;
    },
    getTotalItems() {
        return this.state.order.length;
    },
    getCustomer() {
        return this.state.customerInfo;
    },
    setOrder(item) {
        // Add to price
        this.state.total += item.price;
        // Push item
        this.state.order.push(item);
    },
    // Clear store on checkout
    clearStore() {
        this.state.order = [];
        this.state.customerInfo = [];
        this.state.total = 0;
    }
}

export default OrderStore;