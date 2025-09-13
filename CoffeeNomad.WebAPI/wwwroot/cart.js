const cartButton = document.querySelector(".cart-btn");
const body = document.querySelector("body");
const activeBlock = document.getElementById('active-block');
const cartContainer = document.createElement('div');

cartButton.addEventListener('click', () => {
    // body.style.pointerEvents = 'none';
    activeBlock.classList.add('no-active');
    createCart();
    body.appendChild(cartContainer);
});

function createCart() {
    const cart = document.createElement('div');
    const cartDeleteBtn = document.createElement('button');

    cart.className = 'order';
    cartDeleteBtn.className = 'cart-delete-btn';
    cartDeleteBtn.textContent = 'X';

    cart.innerHTML = `
        <header class="frame">
        <div class="div">
          <h1 class="text-wrapper">Order Details</h1>
          <div class="text-wrapper-2">Order ID #89780</div>
        </div>
        <p class="date-monday-sep">Date: Monday, Sep 23, 2024<br />Time: 5:00 PM</p>
      </header>
      <section class="input-field">
        <label class="frame-2" for="order-type">
          <div class="frame-3">
            <span class="text-wrapper-3">Take Away</span>
          </div>
          <img class="huge-icon-arrows" src="img/direction-down.svg" alt="Dropdown arrow" />
        </label>
        <select id="order-type" class="visually-hidden">
          <option value="takeaway" selected>Take Away</option>
          <option value="dinein">Dine In</option>
          <option value="delivery">Delivery</option>
        </select>
      </section>
      <section class="frame-4" aria-labelledby="order-items">
        <h2 id="order-items" class="visually-hidden">Order Items</h2>
        <article class="frame-5">
          <div class="frame-6">
            <div class="image-wrapper">
              <img class="image" src="img/image 1607.png" alt="Matcha drink" />
            </div>
            <div class="frame-7">
              <div class="frame-8">
                <h3 class="already-have-an">Matcha</h3>
                <div class="text-wrapper-4">Size : S</div>
              </div>
              <div class="text-wrapper-5">$20</div>
            </div>
          </div>
          <div class="frame-9">
            <button class="auto-layout" type="button" aria-label="Remove item">
              <img class="img" src="img/trash.svg" alt="Remove" />
            </button>
            <div class="QTY" role="group" aria-label="Quantity controls for Matcha">
              <button class="delete" type="button" aria-label="Decrease quantity">
                <img class="img" src="img/minus.svg" alt="Minus" />
              </button>
              <div class="div-wrapper">
                <span class="text-wrapper-6">0</span>
              </div>
              <button class="delete" type="button" aria-label="Increase quantity">
                <img class="img" src="img/add.svg" alt="Plus" />
              </button>
            </div>
          </div>
        </article>
        <div class="input-field-wrapper">
          <div class="input-field-2">
            <label class="frame-2" for="matcha-note">
              <img class="note" src="img/note.svg" alt="Note icon" />
              <div class="frame-3">
                <span class="text-wrapper-3">Add Note</span>
              </div>
            </label>
            <input type="text" id="matcha-note" class="visually-hidden" placeholder="Add Note" />
          </div>
        </div>
      </section>
      <article class="frame-10">
        <div class="image-wrapper">
          <img class="image" src="img/image 1607.png" alt="Salted Caramel Truffle" />
        </div>
        <div class="frame-11">
          <div class="frame-8">
            <h3 class="already-have-an-2">Salted Caramel Truffle</h3>
            <div class="text-wrapper-7">Size : S</div>
          </div>
          <div class="text-wrapper-8">$40</div>
        </div>
      </article>
      <div class="frame-12">
        <button class="auto-layout" type="button" aria-label="Remove item">
          <img class="img" src="img/trash.svg" alt="Remove" />
        </button>
        <div class="QTY" role="group" aria-label="Quantity controls for Salted Caramel Truffle">
          <button class="delete" type="button" aria-label="Decrease quantity">
            <img class="img" src="img/minus.svg" alt="Minus" />
          </button>
          <div class="div-wrapper">
            <span class="text-wrapper-6">0</span>
          </div>
          <button class="delete" type="button" aria-label="Increase quantity">
            <img class="img" src="img/add.svg" alt="Plus" />
          </button>
        </div>
      </div>
      <div class="frame-13">
        <div class="input-field-2">
          <label class="frame-2" for="truffle-note">
            <img class="note" src="img/note.svg" alt="Note icon" />
            <div class="frame-3">
              <span class="text-wrapper-3">Add Note</span>
            </div>
          </label>
          <input type="text" id="truffle-note" class="visually-hidden" placeholder="Add Note" />
        </div>
      </div>
      <section class="frame-14" aria-labelledby="payment-method">
        <h2 class="text-wrapper-9" id="payment-method">Payment Method</h2>
        <fieldset class="frame-15">
          <legend class="visually-hidden">Select payment method</legend>
          <label class="item">
            <input type="radio" name="payment" value="cash" class="visually-hidden" />
            <div class="frame-16">
              <div class="icon">
                <div class="group-wrapper">
                  <div class="group">
                    <img src="img/cash.svg" alt="" />
                  </div>
                </div>
              </div>
              <span class="text-wrapper-10">Cash</span>
            </div>
          </label>
          <label class="frame-wrapper">
            <input type="radio" name="payment" value="card" class="visually-hidden" checked />
            <div class="frame-17">
              <div class="icon-2">
                <div class="group-wrapper">
                  <div class="group">
                    <img src="img/card.svg" alt="" />
                  </div>
                </div>
              </div>
              <span class="debit-credit-card">Debit / Credit<br />Card</span>
            </div>
          </label>
          <label class="item">
            <input type="radio" name="payment" value="ewallet" class="visually-hidden" />
            <div class="frame-18">
              <div class="icon">
                <div class="frame-19">
                    <img src="img/e-wallet.svg" alt="" />
                </div>
              </div>
              <span class="text-wrapper-11">E-wallet</span>
            </div>
          </label>
        </fieldset>
      </section>
      <section class="frame-20" aria-labelledby="order-summary">
        <h2 id="order-summary" class="visually-hidden">Order Summary</h2>
        <div class="frame-21">
          <div class="frame-22">
            <div class="frame-23">
              <span class="text-wrapper-12">Subtotal</span>
              <span class="text-wrapper-13">$40</span>
            </div>
            <div class="frame-24">
              <span class="text-wrapper-14">Tax (10%)</span>
              <span class="text-wrapper-13">$4</span>
            </div>
          </div>
          <img class="vector" src="img/vector-7.svg" alt="Divider line" />
        </div>
        <div class="frame-23">
          <span class="text-wrapper-12">Total</span>
          <span class="text-wrapper-13">$44</span>
        </div>
      </section>
      <div class="frame-25">
        <button class="button" type="button">
          <div class="frame-26">
            <span class="button-2">Cancel</span>
          </div>
        </button>
        <button class="button-3" type="submit">
          <div class="frame-26">
            <span class="button-4">Place Order</span>
          </div>
        </button>
      </div>
    `;

    cartDeleteBtn.addEventListener('click', () => {
        activeBlock.classList.remove('no-active');
        body.removeChild(cartContainer);
        body.removeChild(cartDeleteBtn);
    });

    cartContainer.classList.add('cart-container');
    cartContainer.appendChild(cart);
    body.appendChild(cartDeleteBtn);
}
