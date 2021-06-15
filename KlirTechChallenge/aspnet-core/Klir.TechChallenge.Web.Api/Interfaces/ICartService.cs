﻿using Klir.TechChallenge.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KlirTechChallenge.Web.Api.Interfaces
{
    public interface ICartService
    {
        CartItem RecalculateItemPrice(CartItem item);
    }
}