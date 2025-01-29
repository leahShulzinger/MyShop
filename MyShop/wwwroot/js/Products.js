addEventListener("load", () => {
    let cart = JSON.parse(sessionStorage.getItem("cart")) || []
    let category = JSON.parse(sessionStorage.getItem("category")) || []
    sessionStorage.setItem("category", JSON.stringify(category))
    sessionStorage.setItem("cart", JSON.stringify(cart))
    document.querySelector("#ItemsCountText").textContent = cart.length
    filterProducts()
    drawCategory()
    
})

 

const getData = () => {
    const search =
    {
        nameSearch: document.querySelector("#nameSearch").value,
        maxPrice: parseFloat(document.querySelector("#maxPrice").value),
        minPrice: parseFloat(document.querySelector("#minPrice").value),
        categories : sessionStorage.getItem("category")
    }
    return search;
}

const filterProducts = async () => {
    
    
    let { nameSearch, minPrice, maxPrice, categories } = await getData()
    categories = JSON.parse(categories)
    let url = `api/Prodects/`;

    if (nameSearch || maxPrice || minPrice || categories.length!=0) {
        url += '?'
        if (nameSearch)
            url += `&desc=${nameSearch}`
        if (maxPrice)
            url += `&maxPrice=${maxPrice}`
        if (minPrice)
            url += `&minPrice=${minPrice}`
        if (categories.length != 0) {
            for (let i = 0; i < categories.length; i++) {
                url += `&categoryIds=${categories[i]}`
            }
           
            
        }
    }
    try {
        const responsePost = await fetch(url, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        });
        if (responsePost.status == 204)
            alert("not found products")
        if (!responsePost.ok) {
            throw new Error(`HTTP error! status:${response.status}`)
        }
        const dataPost = await responsePost.json();
        console.log(dataPost);
        drawProducts(dataPost)
    }
    catch (error) {
        alert("יש לכם שגיאה")
    }
}
const drawProducts = (products) => {
    document.getElementById("PoductList").innerHTML = ""
    for (let i = 0; i < products.length; i++) {
        drawTemplate(products[i])
    }
    
}
const drawTemplate = (product) => {
    
    let tmp = document.getElementById("temp-card");
    let cloneProduct = tmp.content.cloneNode(true)
    cloneProduct.querySelector("img").src = "./pictures/" + product.image
    cloneProduct.querySelector("h1").textContent = product.productName
    cloneProduct.querySelector(".price").innerText = product.price
    cloneProduct.querySelector(".description").innerText = product.descraption
    cloneProduct.querySelector(".cart").addEventListener('click', () => {addToChart(product)})
    document.getElementById("PoductList").appendChild(cloneProduct)
}
const addToChart= (product) => {
    let products = sessionStorage.getItem("cart")
    products = JSON.parse(products)
    products.push(product)
    sessionStorage.setItem("cart", JSON.stringify(products))
    document.querySelector("#ItemsCountText").textContent = parseInt(document.querySelector("#ItemsCountText").textContent)+1
}
const getCategory = async () => {
    try {
        const responsePost = await fetch("api/Categories", {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            } 
        });
        if (responsePost.status == 204)
            alert("no categories")
        if (!responsePost.ok) {
            throw new Error(`HTTP error! status:${response.status}`)
        }

        const categories = await responsePost.json();
        return categories;
       
    }
    catch (error) {
        alert("יש לכם שגיאה")
    }
    
    
}

const drawCategory =async () => { 
    let categories =await getCategory()
    
    for (let i = 0; i < categories ?.length; i++) {  
    let tmp = document.getElementById("temp-category");
        let cloneCategory = tmp.content.cloneNode(true);
        cloneCategory.querySelector("input").id=i
        cloneCategory.querySelector("input").addEventListener('change', () => { filterCategory(categories[i],i) })
    cloneCategory.querySelector("label").textContent = categories[i].name
    document.getElementById("categoryList").appendChild(cloneCategory)
        }
    
}
const filterCategory = (category,index) => {
    let tmp= document.getElementById(index)
    if (tmp.checked) {
        let categories = sessionStorage.getItem("category")
        categories = JSON.parse(categories) 
        categories.push(category.id)
        sessionStorage.setItem("category",JSON.stringify(categories))
    }
    else {
        let categories = sessionStorage.getItem("category")
        categories = JSON.parse(categories)
        let i = 0;
        for (; i < categories.length && categories[i] != category.id; i++);
        if (i != categories.length)
            categories.splice(i,1)
        sessionStorage.setItem("category", JSON.stringify(categories))
    }
    filterProducts()
}