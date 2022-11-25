#pragma once

#include <mcsc/version.h>

#include <stddef.h>
#include <tuple>
#include <array>

namespace mcsc::datapack {

namespace detail {

using VerFormatItem = struct {
	int			  format;
	mcsc::Version lobound;
	mcsc::Version hibound;
};

};	 // namespace detail

#define makeVerFormatItem(format, lo_1, lo_2, lo_3, hi_1, hi_2, hi_3)                    \
	detail::VerFormatItem {                                                              \
		format, mcsc::makeVersion(lo_1, lo_2, lo_3), mcsc::makeVersion(hi_1, hi_2, hi_3) \
	}

constexpr size_t FormatCount = 7;

constexpr std::array<detail::VerFormatItem, FormatCount> VerFormatTable{
	makeVerFormatItem(4, 1, 13, 0, 1, 14, 4),
	makeVerFormatItem(5, 1, 15, 0, 1, 16, 1),
	makeVerFormatItem(6, 1, 16, 2, 1, 16, 5),
	makeVerFormatItem(7, 1, 17, 0, 1, 17, 1),
	makeVerFormatItem(8, 1, 18, 0, 1, 18, 1),
	makeVerFormatItem(9, 1, 18, 2, 1, 18, 2),
	makeVerFormatItem(10, 1, 19, 0, 1, 19, 2),
};

#undef makeVerFormatItem

};	 // namespace mcsc::datapack
